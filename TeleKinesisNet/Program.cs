// ///-----------------------------------------------------------------
// ///   Program.cs
// ///   Alvaro Muir, alvaro@coca-cola.com
// ///   MDS Global Analytics
// ///   11/25/2019
// ///-----------------------------------------------------------------
using System;
using System.Configuration;
using CommandLine;
namespace TeleKinesisNet
{
    public class Program
    {
        public class Options
        {
            [Option('n', "name", Required = true, HelpText = "The name of Kinesis stream.")]
            public String name { get; set; }

            [Option('r', "region", Required = true, HelpText = "The AWS Region.")]
            public String region { get; set; }

            [Option('e', "enriched", Required = false, HelpText = "The results are enriched.")]
            public bool enriched { get; set; }

            [Option('l', "limit", Required = false, HelpText = "The records per shard limit; default 25, minimum is 2")]
            public int limit { get; set; }

            [Option('i', "interval", Required = false, HelpText = "The response intervals; default 1 second.")]
            public float interval { get; set; }

            [Option('m', "max", Required = false, HelpText = "The maximum records to return; default 0 (infinite).")]
            public int max { get; set; }

            [Option('h', "namespace", Required = false, HelpText = "The Azure Event Hub namespace.")]
            public String _namespace { get; set; }

            [Option('p', "path", Required = false, HelpText = "The Azure Event Hub instance path/name")]
            public String path { get; set; }

            [Option('k', "key", Required = false, HelpText = "The Azure Event Hub connection string key name.")]
            public String key { get; set; }

            [Option('s', "secret", Required = false, HelpText = "The Azure Event Hub connection string secret.")]
            public String secret { get; set; }    

        }

        public static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AppName"]))
            {
                Parser.Default.ParseArguments<Options>(args).WithParsed<Options>
                (
                    opts => Consumer.ConsumeStream
                    (
                        opts.name, opts.region, opts.enriched, opts.limit, opts.interval,
                        opts.max, opts._namespace, opts.path, opts.key, opts.secret
                    )
                );
            }
            else
            {
                string name = ConfigurationManager.AppSettings["KinesisStreamName"];
                string region = ConfigurationManager.AppSettings["AWSRegion"];
                bool enriched = ConfigurationManager.AppSettings["KinesisStreamEnriched"] == null ? false : bool.Parse(ConfigurationManager.AppSettings["KinesisStreamEnriched"]) ;
                int limit = Int32.Parse(ConfigurationManager.AppSettings["KinesisStreamLimit"]);
                float interval = float.Parse(ConfigurationManager.AppSettings["KinesisStreamInterval"]);
                int max = ConfigurationManager.AppSettings["KinesisStreamMax"] == null ? 0 : Int32.Parse(ConfigurationManager.AppSettings["KinesisStreamMax"]);
                string _namespace = ConfigurationManager.AppSettings["EventHubsNamespace"];
                string path = ConfigurationManager.AppSettings["EventHubsPath"];
                string key = ConfigurationManager.AppSettings["EventHubsKey"];
                string secret = ConfigurationManager.AppSettings["EventHubsSecret"];

                Consumer.ConsumeStream
                (
                    name, region, enriched, limit, interval, max, _namespace,
                    path, key, secret
                );
            }

        }
    }
}
