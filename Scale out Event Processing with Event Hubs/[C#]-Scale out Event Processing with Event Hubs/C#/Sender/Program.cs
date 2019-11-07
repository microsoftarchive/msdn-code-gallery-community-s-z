namespace Sender
{
    using System.Configuration;
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static string eventHubName;

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect number of arguments. Expected: Sender <eventhubname>.");
                Console.ResetColor();
                Console.WriteLine("Press Ctrl-C or Enter to exit.");
                Console.ReadLine();
                return;
            }
            else
            {
                eventHubName = args[0];
                Console.WriteLine("EventHub name: " + eventHubName);
            }

            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            if (CreateEventHub())
            {
                SendingRandomMessages().Wait();
            }
        }

        static async Task SendingRandomMessages()
        {
            var eventHubConnectionString = GetEventHubConnectionString();
            var eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString, eventHubName);
            while (true)
            {
                try
                {
                    var message = Guid.NewGuid().ToString();
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now.ToString(), message);
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                    Console.ResetColor();
                }

                // we send it slowly...
                await Task.Delay(200);
            }            
        }

        static bool CreateEventHub()
        {
            try
            {
                var manager = NamespaceManager.CreateFromConnectionString(GetEventHubConnectionString());

                // Create the Event Hub
                Console.WriteLine("Creating Event Hub...");
                manager.CreateEventHubIfNotExistsAsync(eventHubName).Wait();
                Console.WriteLine("Event Hub is created...");
                return true;
            }
            catch (AggregateException agexp)
            {
                Console.WriteLine(agexp.Flatten());
                return false;
            }
        }
        
        static string GetEventHubConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Did not find Service Bus connections string in appsettings (app.config)");
                return string.Empty;
            }
            try
            {
                var builder = new ServiceBusConnectionStringBuilder(connectionString);
                builder.TransportType = TransportType.Amqp;
                return builder.ToString();
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.ResetColor();
            }

            return null;
        }
    }
}
