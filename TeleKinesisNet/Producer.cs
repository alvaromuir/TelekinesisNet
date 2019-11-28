// ///-----------------------------------------------------------------
// ///   Producer.cs
// ///   Alvaro Muir, alvaro@coca-cola.com
// ///   MDS Global Analytics
// ///   11/27/2019
// ///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;

namespace TeleKinesisNet
{
    public class Producer
    {
        public static EventHubClient eventHubClient;

        public Producer(String _namespace, String key, String secret, String path)
        {
            if(key is null || secret is null || path is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: key, secret or path is missing");
                Console.ResetColor();
                Environment.Exit(0);
            }
            String connectionString = $"Endpoint=sb://{_namespace}.servicebus.windows.net/;SharedAccessKeyName={key};SharedAccessKey={secret};EntityPath={path}";
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionString);
        }

        public EventHubClient GetEventHubClient()
        {
            return eventHubClient;
        }

        // Uses the event hub client to push the record.
        public void SendMessageToEventHub(IDictionary<string, object> record, String partitionKey)
        {
            try
            {
                // todo: properly write to logging
                #if DEBUG
                Console.WriteLine($"Sending message: {JsonConvert.SerializeObject(record["SequenceNumber"])} - PartitionKey {partitionKey}");
                #endif
                eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(record))), partitionKey);
            }
            catch (Exception exception)
            {
                // todo: properly write to logging
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.StackTrace}");
                Environment.Exit(0);
            }

            Task.Delay(10);
        }
    }
}
