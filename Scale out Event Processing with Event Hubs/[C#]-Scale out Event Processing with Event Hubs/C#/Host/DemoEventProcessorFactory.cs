namespace Host
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.ServiceBus.Messaging;

    /// <summary>
    /// The demo event processor factory.
    /// where you can keep your monitoring of your processor status.
    /// </summary>
    public class DemoEventProcessorFactory : IEventProcessorFactory
    {        
        private readonly ConcurrentDictionary<string, DemoEventProcessor> eventProcessors = new ConcurrentDictionary<string, DemoEventProcessor>();

        private readonly ConcurrentQueue<DemoEventProcessor> closedProcessors = new ConcurrentQueue<DemoEventProcessor>();

        public DemoEventProcessorFactory(string hostname)
        {
            this.HostName = hostname;
        }

        public string HostName { get; private set; }

        public int ActiveProcesors
        {
            get
            {
                return this.eventProcessors.Count;
            }
        }

        public int TotalMessages
        {
            get
            {
                var amount = this.eventProcessors.Select(p => p.Value.TotalMessages).Sum();
                amount += this.closedProcessors.Select(p => p.TotalMessages).Sum();
                return amount;
            }
        }

        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            var processor = new DemoEventProcessor();
            processor.ProcessorClosed += this.ProcessorOnProcessorClosed;
            this.eventProcessors.TryAdd(context.Lease.PartitionId, processor);
            return processor;
        }

        public Task WaitForAllProcessorsInitialized(TimeSpan timeout)
        {
            return this.WaitForAllProcessorsCondition(p => p.IsInitialized, timeout);
        }

        public Task WaitForAllProcessorsClosed(TimeSpan timeout)
        {
            return this.WaitForAllProcessorsCondition(p => p.IsClosed, timeout);
        }

        public async Task WaitForAllProcessorsCondition(Func<DemoEventProcessor, bool> predicate, TimeSpan timeout)
        {
            TimeSpan sleepInterval = TimeSpan.FromSeconds(2);
            while (!this.eventProcessors.Values.All(predicate))
            {
                if (timeout > TimeSpan.Zero)
                {
                    timeout = timeout.Subtract(sleepInterval);
                }
                else
                {
                    throw new TimeoutException("Condition not satisfied within expected timeout.");
                }

                await Task.Delay(sleepInterval);
            }
        }

        private void ProcessorOnProcessorClosed(object sender, EventArgs eventArgs)
        {
            var processor = sender as DemoEventProcessor;
            if (processor != null)
            {
                this.eventProcessors.TryRemove(processor.Context.Lease.PartitionId, out processor);
                this.closedProcessors.Enqueue(processor);
            }
        }
    }
}
