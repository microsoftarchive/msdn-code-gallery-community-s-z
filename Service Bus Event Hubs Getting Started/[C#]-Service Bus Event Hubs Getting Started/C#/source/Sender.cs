using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ServiceBus.Samples
{
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Samples.SessionMessages;
    using Newtonsoft.Json;

    public class Sender
    {
        const int numberOfDevices = 1000;
        string eventHubName;
        int numberOfMessages;
        public Sender(string eventHubName, int numberOfMessages)
        {
            this.eventHubName = eventHubName;
            this.numberOfMessages = numberOfMessages;
        }

        public void SendEvents()
        {
            // Create EventHubClient
            EventHubClient client = EventHubClient.Create(this.eventHubName);
			
			try
			{
			    List<Task> tasks = new List<Task>();
			    // Send messages to Event Hub
			    Console.WriteLine("Sending messages to Event Hub {0}", client.Path);
			    Random random = new Random();
			    for (int i = 0; i < this.numberOfMessages; ++i)
			    {
			        // Create the device/temperature metric
			        MetricEvent info = new MetricEvent() {DeviceId = random.Next(numberOfDevices), Temperature = random.Next(100)};
			        var serializedString = JsonConvert.SerializeObject(info);
			        EventData data = new EventData(Encoding.UTF8.GetBytes(serializedString))
			        {
			            PartitionKey = info.DeviceId.ToString()
			        };

			        // Set user properties if needed
			        data.Properties.Add("Type", "Telemetry_" + DateTime.Now.ToLongTimeString());
			        OutputMessageInfo("SENDING: ", data, info);

			        // Send the metric to Event Hub
			        tasks.Add(client.SendAsync(data));
			    }
			    ;

			    Task.WaitAll(tasks.ToArray());
			}
			catch (Exception exp)
			{
			    Console.WriteLine("Error on send: " + exp.Message);
			}

            client.CloseAsync().Wait();
        }

        static void OutputMessageInfo(string action, EventData data, MetricEvent info)
        {
            if (data == null)
            {
                return;
            }
            if (info != null)
            {
                Console.WriteLine("{0}{1} - Device {2}, Temperature {3}.", action, data, info.DeviceId, info.Temperature);
            }
        }
    }
}
