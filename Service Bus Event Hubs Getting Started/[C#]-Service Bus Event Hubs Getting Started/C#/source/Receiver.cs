namespace Microsoft.ServiceBus.Samples.SessionMessages
{
    using Microsoft.ServiceBus.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    class Receiver
    {
        #region Fields
        string eventHubName;
        EventHubConsumerGroup defaultConsumerGroup;
        string eventHubConnectionString;
        EventProcessorHost eventProcessorHost;
        #endregion

        public Receiver(string eventHubName, string eventHubConnectionString)
        {
            this.eventHubConnectionString = eventHubConnectionString;
            this.eventHubName = eventHubName;
        }

        public void MessageProcessingWithPartitionDistribution()
        {
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString, this.eventHubName);

            // Get the default Consumer Group
            defaultConsumerGroup = eventHubClient.GetDefaultConsumerGroup();
            string blobConnectionString = ConfigurationManager.AppSettings["AzureStorageConnectionString"]; // Required for checkpoint/state
            eventProcessorHost = new EventProcessorHost("singleworker", eventHubClient.Path, defaultConsumerGroup.GroupName, this.eventHubConnectionString, blobConnectionString);
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>().Wait();
        }

        public void UnregisterEventProcessor()
        {
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}
