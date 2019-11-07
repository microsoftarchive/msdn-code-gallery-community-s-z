

namespace Senders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Threading;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static string eventHubName;
        static int numberOfPartitions;
        const string consumerGroupName = "TestEventProcessApplication";

        static void Main(string[] args)
        {
            ParseArgs(args);
            CreateEventHubAndConsumerGroup();
            Console.WriteLine("Press Ctrl-C to stop sending events to EventHub {0}", eventHubName);
            SendEventsAsync().Wait();
        }

        static void ParseArgs(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("Incorrect number of arguments. Expected Args <eventhubname> [numberofPartitions]", args.ToString());
            }
            else
            {
                eventHubName = args[0];
                Console.WriteLine("ehnanme: " + eventHubName);
                numberOfPartitions = args.Length > 1 ? Int32.Parse(args[1]) : 5;
            }
        }

        public static void CreateEventHubAndConsumerGroup()
        {
            try
            {
                NamespaceManager manager = NamespaceManager.CreateFromConnectionString(GetServiceBusConnectionString());
                // Create the Event Hub
                Console.WriteLine("Creating Event Hub...");
                EventHubDescription ehd = new EventHubDescription(eventHubName);
                //ehd.PartitionCount = numberOfPartitions;
                manager.CreateEventHubIfNotExistsAsync(ehd.Path).Wait();
                manager.CreateConsumerGroupIfNotExistsAsync(ehd.Path, consumerGroupName).Wait();
            }
            catch (AggregateException agexp)
            {
                Console.WriteLine(agexp.Flatten());
            }
        }

        static async Task SendEventsAsync()
        {
            // Create EventHubClient
            EventHubClient client = EventHubClient.Create(eventHubName);

            while (true)
            {
                try
                {
                    // Send messages to Event Hub
                    Console.WriteLine("Sending messages to Event Hub {0}", client.Path);
                    string messageBody = Guid.NewGuid().ToString();

                    // Create the device/temperature metric
                    EventData data = new EventData(Encoding.UTF8.GetBytes(messageBody));

                    // Send the metric to Event Hub
                    await client.SendAsync(data);
                    Console.WriteLine("Sent message {0} ", messageBody);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error on send: " + exp.Message);
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private static string GetServiceBusConnectionString()
        {
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Did not find Service Bus connections string in appsettings (app.config)");
                return string.Empty;
            }
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(connectionString);
            builder.TransportType = TransportType.Amqp;
            return builder.ToString();
        }
    }
}
