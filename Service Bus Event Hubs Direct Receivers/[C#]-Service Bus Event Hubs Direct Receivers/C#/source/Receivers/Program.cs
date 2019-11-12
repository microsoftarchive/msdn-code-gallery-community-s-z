namespace DirectReceivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static string partitionId;
        static string eventHubName;
        static string offset;
        const string consumerGroupName = "TestEventProcessApplication";
        static long receiverEpoch = 0; 

        static void Main(string[] args)
        {
            ParseArgs(args);
            MessageProcessingWithReceiveLoop().Wait();

            Console.WriteLine("Press Ctrl-C to stop the worker process");
            Console.ReadLine();
        }

        static void ParseArgs(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Incorrect number of arguments. Expected Args <eventhubname> <partitionId> <receiverEpoch> [startingoffset]", args.ToString());
            }
            else
            {
                eventHubName = args[0];
                Console.WriteLine("ehnanme: " + eventHubName);

                partitionId = args[1];
                Console.WriteLine("partitionId: " + partitionId);

                if (args.Length > 2)
                {
                    receiverEpoch = long.Parse(args[2]);
                    Console.WriteLine("receiverEpoch: " + receiverEpoch);
                }

                if (args.Length > 3)
                {
                    offset = args[3];
                }
            }
        }

        private static async Task MessageProcessingWithReceiveLoop()
        {
            string eventHubConnectionString = GetServiceBusConnectionString();
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString, eventHubName);
            EventHubConsumerGroup consumerGroup = eventHubClient.GetConsumerGroup(consumerGroupName);
            EventHubReceiver consumer;
            
            if (offset != null)
            {
                consumer = await consumerGroup.CreateReceiverAsync(partitionId, offset, receiverEpoch); // All messages
            }
            else
            {
                // Default to get oldest message
                consumer = await consumerGroup.CreateReceiverAsync(partitionId, receiverEpoch); // All messages
            }
           
            do
            {
                try
                {
                    var message = await consumer.ReceiveAsync();
                    if (message != null)
                    {
                        string msg;
                        var info = message.GetBytes();
                        msg = Encoding.UTF8.GetString(info);

                        Console.WriteLine("Processing: Seq number {0} Offset {1}  Partition {2} EnqueueTimeUtc {3} Message {4}", 
                            message.SequenceNumber, message.Offset, message.PartitionKey, message.EnqueuedTimeUtc.ToShortTimeString(), msg);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("exception on receive {0}", exception.Message);
                }
                        
            } while (true);
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
