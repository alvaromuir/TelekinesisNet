// ///-----------------------------------------------------------------
// ///   Producer.cs
// ///   Alvaro Muir, alvaro@coca-cola.com
// ///   MDS Global Analytics
// ///   11/25/2019
// ///-----------------------------------------------------------------
using System;
using System.Linq;
using System.Net;
using System.Text;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using Snowplow.Analytics.Exceptions;
using Snowplow.Analytics.Json;
using Thrift.Protocol;


namespace TeleKinesisNet
{
    public class Consumer
    {
        private static EventHubClient eventHubClient;
        private static Producer producer;
        private static String partitionKey;

        // Kinesis stream consumer. Requires a stream name and region. If the stream is 'snowplow enriched' that is
        // notated by the enriched flag.
        public static void ConsumeStream(string streamName, string region, bool enriched,
            int limit = 25, float interval = 1.0F, int maxRecords = 0,
            String _namespace = null, String path = null, String key = null, String secret = null)
        {
            if (limit < 2) { limit = 2; }
            if (interval < 1) { interval = 1.0F; }

            var client = new AmazonKinesisClient();

            if (_namespace != null)
            {
                producer = new Producer(_namespace, key, secret, path);
                eventHubClient = producer.GetEventHubClient();
                PrintBanner(streamName, region, interval, _namespace, path);

                partitionKey = $"events-{DateTime.Now.ToString("yyyy-MM-dd-HH")}";
            }
            else
            {
                PrintBanner(streamName, region, interval);
            }


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
                                var body = WebUtility.UrlDecode(payload["Body"].ToString());
                                payload["Body"] = QueryHelpers.ParseQuery(body);
                                record["Data"] = payload;
                            }
                            if (_namespace != null)
                            {
                                // todo: pool and batch send messages
                                producer.SendMessageToEventHub(record, partitionKey);
                            }
                            else
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(record));
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


        // Simple thrift deserializer
        public static T Deserialize<T>(byte[] data) where T : TBase, new()
        {
            T result = new T();
            var buffer = new Thrift.Transport.Client.TMemoryBufferTransport(data);
            TProtocol tProtocol = new TBinaryProtocol(buffer);
            result.ReadAsync(tProtocol);
            return result;
        }

        // Simple console banner
        private static void PrintBanner(string streamName = null, string region = null, float interval = 0F,
            String _namespace = null, String path = null)
        {
            String message;
            if (_namespace != null)
            {
                message = $"sending '{streamName}' AWS Kinesis events from Azure Events Hub {_namespace}/{path}";
            }
            else
            {
                message = $"listening on the '{streamName}' stream in the {region} region at {interval} second intervals";
            }
            Console.WriteLine(new String('-', message.Length));
            Console.WriteLine(message);
            Console.WriteLine(new String('-', message.Length));
        }

    }
}
