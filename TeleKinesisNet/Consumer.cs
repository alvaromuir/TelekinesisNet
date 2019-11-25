using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using CommandLine;
using Newtonsoft.Json;
using Snowplow.Analytics.Exceptions;
using Snowplow.Analytics.Json;
using Thrift.Protocol;


namespace TeleKinesisNet
{
    public class Consumer
    {
        
        private static void ConsumeStream(string streamName, string region, bool enriched, int limit = 25, float interval = 1.0F, int maxRecords = 0)
        {
            if (limit < 2) { limit = 2; }
            if (interval < .5) { interval = 0.5F; }

            var client = new AmazonKinesisClient();
            PrintBanner(streamName, region, interval);
            
            var streamRequest = new DescribeStreamRequest();
            streamRequest.StreamName = streamName;

            var shard = client.DescribeStreamAsync(streamRequest).Result.StreamDescription.Shards[0];

            var iteratorRequest = new GetShardIteratorRequest();
            iteratorRequest.StreamName = streamName;
            iteratorRequest.ShardId = shard.ShardId;
            iteratorRequest.ShardIteratorType = "LATEST";
         
            var recordsRequest = new GetRecordsRequest();
            recordsRequest.ShardIterator = client.GetShardIteratorAsync(iteratorRequest).Result.ShardIterator;
            recordsRequest.Limit = limit;

            var output = client.GetRecordsAsync(recordsRequest).Result;
            UTF8Encoding utf8 = new UTF8Encoding();

            int count = 0;

            while (true)
            {
                output = client.GetRecordsAsync(recordsRequest).Result;
                var records = output.Records;

                if (records != null ? true : (records.Any()))
                {
                    foreach (Record recordStream in records)
                    {
                        if (count > maxRecords)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            var record = recordStream.ToDictionary();
                            
                            
                            if (enriched)
                            {
                                try
                                {
                                    record["Data"] = JsonConvert.DeserializeObject(EventTransformer.Transform(utf8.GetString(recordStream.Data.ToArray())));
                                }
                                catch (SnowplowEventTransformationException e)
                                {
                                    e.ErrorMessages.ForEach((message) => Console.WriteLine(message));
                                }
                            }
                            else
                            {
                                var payload = Deserialize<CollectorPayload>(recordStream.Data.ToArray()).ToDictionary();
                                var body = HttpUtility.ParseQueryString(WebUtility.UrlDecode(payload["Body"].ToString()));
                                payload["Body"] = body.AllKeys.ToDictionary(k => k, k => body[k]);
                                record["Data"] = payload;
                            }
                            Console.WriteLine(JsonConvert.SerializeObject(record));
                            if (maxRecords > 0)
                            {
                                count++;
                            }
                        }
                    }
                }
                    if (maxRecords > 0)
                {
                    count++;
                }
            }


        }

        public static T Deserialize<T>(byte[] data) where T : TBase, new()
        {
            T result = new T();
            var buffer = new Thrift.Transport.Client.TMemoryBufferTransport(data);
            TProtocol tProtocol = new TBinaryProtocol(buffer);
            result.ReadAsync(tProtocol);
            return result;
        }

        private static void PrintBanner(string streamName, string region, float interval)
        {
            string message = $"listening on the '{streamName}' stream in the {region} region at {interval} second intervals";
            Console.WriteLine(new String('-', message.Length));
            Console.WriteLine(message);
            Console.WriteLine(new String('-', message.Length));
        }


        public class Options
        {
            [Option('n', "name", Required = true, HelpText = "The name of Kinesis stream.")]
            public String name { get; set; }

            [Option('r', "region", Required = true, HelpText = "The AWS Region.")]
            public String region { get; set; }

            [Option('e', "enriched", Required = false, HelpText = "The results are enriched.")]
            public bool enriched { get; set; }

            [Value(25, MetaName = "limit", HelpText = "The records per shard limit; default 25, minimum is 2")]
            public int limit { get; set; }

            [Value(1, MetaName = "interval", HelpText = "The response intervals; default 1 second.")]
            public float interval { get; set; }

            [Value(0, MetaName = "max", HelpText = "The maximum records to return; default 0 (infinite).")]
            public int max { get; set; }

        }

        public static void Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => ConsumeStream(opts.name, opts.region, opts.enriched, opts.limit, opts.interval));
                //.WithNotParsed<Options>((errs) => HandleParseError(errs));
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            throw new NotImplementedException();
        }
    }
}
