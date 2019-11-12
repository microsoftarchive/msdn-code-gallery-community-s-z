namespace Host
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;

    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static string eventHubName;

        static string hostName;

        static string consumerGroupName;

        static EventProcessorHost host;

        static DemoEventProcessorFactory factory;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect number of arguments. Expected: Host <eventhubname> <hostname> [consumergrou].");
                Console.ResetColor();
                Console.WriteLine("Press Ctrl-C or Enter to exit.");
                Console.ReadLine();
                return;
            }

            eventHubName = args[0];
            Console.WriteLine("EventHub name: " + eventHubName);

            hostName = args[1];
            Console.WriteLine("Host name: " + hostName);

            if (args.Length > 2)
            {
                consumerGroupName = args[2];
            }
            else
            {
                consumerGroupName = EventHubConsumerGroup.DefaultGroupName;
            }

            Console.WriteLine("ConsumerGroup name: " + consumerGroupName);

            Console.WriteLine("Press Ctrl-C or Q to stop the host process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();

            StartHost().Wait();

            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Total received messages: {0}", factory.TotalMessages);
                    host.UnregisterEventProcessorAsync().Wait();
                    return;
                }
            }
        }

        private static async Task StartHost()
        {
            var eventHubConnectionString = GetEventHubConnectionString();
            var storageConnectionString = GetStorageConnectionString();

            // here it's using eventhub as lease name. but it can be specified as any you want.
            // if the host is having same lease name, it will be shared between hosts.
            // by default it is using eventhub name as lease name.
            host = new EventProcessorHost(
                hostName,
                eventHubName,
                consumerGroupName,
                eventHubConnectionString,
                storageConnectionString, eventHubName.ToLowerInvariant());

            factory = new DemoEventProcessorFactory(hostName);

            try
            {
                Console.WriteLine("{0} > Registering host: {1}", DateTime.Now.ToString(), hostName);
                var options = new EventProcessorOptions();
                options.ExceptionReceived += OptionsOnExceptionReceived;
                await host.RegisterEventProcessorFactoryAsync(factory);
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                Console.ResetColor();
            }
        }

        private static void OptionsOnExceptionReceived(object sender, ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            // by receiving host exception, you could respond to the error, e.g. restart the host.
            Console.WriteLine("Received exception, action: {0}, messae： {1}.", exceptionReceivedEventArgs.Action, exceptionReceivedEventArgs.Exception.Message);
        }

        static string GetEventHubConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Did not find Service Bus connections string in appsettings (app.config)");
                Console.ResetColor();
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

            return string.Empty;
        }

        private static string GetStorageConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Did not find storage connections string in appsettings (app.config) as host needs blob storage.");
                Console.ResetColor();
                return string.Empty;
            }

            return connectionString;
        }
    }
}
