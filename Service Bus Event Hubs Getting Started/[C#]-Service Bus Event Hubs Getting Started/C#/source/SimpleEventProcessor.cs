namespace Microsoft.ServiceBus.Samples
{
    using System.Diagnostics;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus.Messaging;
    using Newtonsoft.Json;

    public class SimpleEventProcessor : IEventProcessor
    {
        IDictionary<string, int> map;
        PartitionContext partitionContext;
        Stopwatch checkpointStopWatch;

        public SimpleEventProcessor()
        {
            this.map = new Dictionary<string, int>();
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine(string.Format("SimpleEventProcessor initialize.  Partition: '{0}', Offset: '{1}'", context.Lease.PartitionId, context.Lease.Offset));
            this.partitionContext = context;
            this.checkpointStopWatch = new Stopwatch();
            this.checkpointStopWatch.Start();
            return Task.FromResult<object>(null);
        }

        public async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> events)
        {
            try
            {
                foreach (EventData eventData in events)
                {
                    int data;
                    var newData = this.DeserializeEventData(eventData);
                    string key = eventData.PartitionKey;

                    // Name of device generating the event acts as hash key to retrieve average computed for it so far
                    if (!this.map.TryGetValue(key, out data))
                    {
                        // If this is the first time we got data for this device then generate new state
                        this.map.Add(key, -1);
                    }

                    // Update data
                    data = newData.Temperature;
                    this.map[key] = data;

                    Console.WriteLine(string.Format("Message received.  Partition: '{0}', Device: '{1}', Data: '{2}'",
                        this.partitionContext.Lease.PartitionId, key, data));
                }

                //Call checkpoint every 5 minutes, so that worker can resume processing from the 5 minutes back if it restarts.
                if (this.checkpointStopWatch.Elapsed > TimeSpan.FromMinutes(5))
                {
                    await context.CheckpointAsync();
                    this.checkpointStopWatch.Restart();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error in processing: " + exp.Message);
            }
        }

        public async Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine(string.Format("Processor Shuting Down.  Partition '{0}', Reason: '{1}'.", this.partitionContext.Lease.PartitionId, reason.ToString()));
            if (reason == CloseReason.Shutdown)
            {
                await context.CheckpointAsync();
            }
        }

        MetricEvent DeserializeEventData(EventData eventData)
        {
            return JsonConvert.DeserializeObject<MetricEvent>(Encoding.UTF8.GetString(eventData.GetBytes()));
        }
    }
}
