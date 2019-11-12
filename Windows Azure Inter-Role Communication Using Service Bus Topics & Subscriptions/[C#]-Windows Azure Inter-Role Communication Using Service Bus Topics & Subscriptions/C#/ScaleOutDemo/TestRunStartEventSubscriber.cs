//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace ScaleOutDemo
{
    #region Using references
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Data.Services.Client;
    using System.Configuration;
    using System.Threading;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Description;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;

    using ScaleOutDemo.Contracts.Data;
    #endregion

    public class TestRunStartEventSubscriber : InterRoleCommunicationEventSubscriberBase<TestRunStartEvent>
    {
        private readonly IInterRoleCommunicationExtension interRoleCommunicator;
        private readonly CloudTableClient tableClient;
        private readonly UnicastACKSubscriber ackSubscriber;
        private readonly string testRunsTableName;

        public TestRunStartEventSubscriber(IInterRoleCommunicationExtension communicator, CloudTableClient tableClient, string testRunsTableName, UnicastACKSubscriber ackSubscriber)
        {
            this.interRoleCommunicator = communicator;
            this.tableClient = tableClient;
            this.testRunsTableName = testRunsTableName;
            this.ackSubscriber = ackSubscriber;
        }

        /// <summary>
        /// Receives a notification when a new inter-role communication event occurs.
        /// </summary>
        public override void OnNext(TestRunStartEvent msg)
        {
            var numInstances = RoleEnvironment.CurrentRoleInstance.Role.Instances.Count - 1;

            var topicBaseCommunicator = this.interRoleCommunicator as InterRoleCommunicationExtension;
            if (topicBaseCommunicator != null)
            {
                topicBaseCommunicator.Settings.EnableAsyncPublish = msg.EnableAsyncPublish;
                topicBaseCommunicator.Settings.EnableAsyncDispatch = msg.EnableAsyncDispatch;
            }

            if (msg.RequireTopicCleanup)
            {
                // Delete the IRC topic first so that instances will have enough time to recreate senders and receivers.
                var serviceBusSettings = ConfigurationManager.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;
                var pubsubType = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingPubSubType];

                if (pubsubType.Equals(CommonConsts.ConfigSettingPubSubTypeValueTopic))
                {
                    var topicEndpoint = serviceBusSettings.Endpoints.Get(CommonConsts.TopicServiceBusEndpointName);
                    var credentials = TokenProvider.CreateSharedSecretTokenProvider(topicEndpoint.IssuerName, topicEndpoint.IssuerSecret);
                    var address = ServiceBusEnvironment.CreateServiceUri("sb", topicEndpoint.ServiceNamespace, String.Empty);
                    var nsManager = new NamespaceManager(address, credentials);

                    if (nsManager.GetTopics().Where(t => String.Compare(t.Path, topicEndpoint.TopicName, true) == 0).Count() > 0)
                    {
                        nsManager.DeleteTopic(topicEndpoint.TopicName);
                    }
                }
            }

            if (msg.PurgeTraceLogTable)
            {
                // Purge WADLogsTable.
                PurgeTraceLogTable();
            }

            // Tell ACK subscriber how many messages it should expect to receive and reset the ACK counter.
            this.ackSubscriber.SetExpectedAckCount(msg.MessageCount * numInstances);
            this.ackSubscriber.ResetAckCounter();

            var testRun = new TestRunTableEntity()
            {
                TestRunID = msg.TestRunID,
                MessageCount = msg.MessageCount,
                MessageSize = msg.MessageSize,
                InstanceCount = numInstances,
                StartDateTime = DateTime.UtcNow,
                EndDateTime = new DateTime(1900, 1, 1)
            };

            var testRunsTable = new TestRunEntityTableContext(this.tableClient.BaseUri.ToString(), this.tableClient.Credentials);
            testRunsTable.TableName = this.testRunsTableName;

            try
            {
                testRunsTable.AddTestRun(testRun);
            }
            catch (DataServiceRequestException ex)
            {
                if (ex.IsEntityAlreadyExists())
                {
                    testRunsTable.UpdateTestRun(testRun);
                }
            }

            using (TraceManager.WorkerRoleComponent.TraceScope("Publishing IRC events", msg.TestRunID, msg.MessageCount, msg.MessageSize))
            {
                for (int i = 1; i <= msg.MessageCount; i++)
                {
                    DemoPayload payload = new DemoPayload(msg.TestRunID, i, numInstances, DateTime.UtcNow);

                    // Create a data portion of the payload equal to the message size specified in the test run settings.
                    payload.Data = new byte[msg.MessageSize];
                    (new Random()).NextBytes(payload.Data);

                    InterRoleCommunicationEvent ircEvent = new InterRoleCommunicationEvent(payload);

                    // Update publish time so that it accurately reflects the current time.
                    payload.PublishTickCount = HighResolutionTimer.CurrentTickCount;
                    payload.PublishTime = DateTime.UtcNow;

                    // Publish the IRC event.
                    this.interRoleCommunicator.Publish(ircEvent);
                }
            }
        }

        /// <summary>
        /// Gets notified that the provider has successfully finished sending notifications to all observers.
        /// </summary>
        public override void OnCompleted()
        {
            // Doesn't have to do anything upon completion.
        }

        /// <summary>
        /// Gets notified that the provider has experienced an error condition.
        /// </summary>
        public override void OnError(Exception ex)
        {
            // Report on the error through common logging/tracing infrastructure.
            TraceManager.WorkerRoleComponent.TraceError(ex);
        }

        private void PurgeTraceLogTable()
        {
            var storageAccount = new CloudStorageAccount(this.tableClient.Credentials, null, null, this.tableClient.BaseUri);
            var tableStorage = storageAccount.CreateCloudTableClient();

            tableStorage.DeleteTableIfExist(CommonConsts.DiagnosticTraceLogsTableName);

            while (true)
            {
                try
                {
                    if (!tableStorage.DoesTableExist(CommonConsts.DiagnosticTraceLogsTableName))
                    {
                        tableStorage.CreateTableIfNotExist(CommonConsts.DiagnosticTraceLogsTableName);
                        break;
                    }
                }
                catch (StorageClientException ex)
                {
                    Exception error = ex;
                    bool terminate = true;

                    while (error.InnerException != null)
                    {
                        if (error.InnerException is DataServiceRequestException)
                        {
                            DataServiceRequestException dsError = error.InnerException as DataServiceRequestException;
                            if (dsError.IsTableBeingDeleted())
                            {
                                terminate = false;
                            }
                        }

                        error = error.InnerException;
                    }

                    if (terminate)
                    {
                        break;
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
    }
}
