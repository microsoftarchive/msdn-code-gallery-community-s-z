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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Text.RegularExpressions;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Diagnostics;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;

    using ScaleOutDemo.Contracts.Data;
    #endregion

    public class WorkerRole : RoleEntryPoint
    {
        private IInterRoleCommunicationExtension interRoleCommunicator;
        private IList<IDisposable> activeSubscription = new List<IDisposable>();
        private CloudTableClient resultTableStorage;
        private DiagnosticMonitor diagnosticMonitor;

        public override void Run()
        {
            TraceManager.WorkerRoleComponent.TraceInfo("ScaleOutDemo entry point called");

            while (true)
            {
                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// Called by Windows Azure service runtime to initialize the role instance.
        /// </summary>
        /// <returns>Return true if initialization succeeds, otherwise returns false.</returns>
        public override bool OnStart()
        {
            try
            {
                StartDiagnosticMonitor();

                ServicePointManager.DefaultConnectionLimit = Environment.ProcessorCount * 12;
                ServicePointManager.UseNagleAlgorithm = false;

                TraceManager.WorkerRoleComponent.TraceIn();

                var serviceBusSettings = ConfigurationManager.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;

                var pubsubType = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingPubSubType];
                var storageAccountName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccount];
                var storageAccountKey = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccountKey];
                var testResultsTableName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingTestResultsTableName];
                var testRunsTableName = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingTestRunsTableName];

                if (pubsubType.Equals(CommonConsts.ConfigSettingPubSubTypeValueTopic))
                {
                    var topicEndpoint = serviceBusSettings.Endpoints.Get(CommonConsts.TopicServiceBusEndpointName);

                    var ircComponent = new InterRoleCommunicationExtension(topicEndpoint);
                    ircComponent.Settings.RetryPolicy.RetryOccurred += (currentRetryCount, ex, delay) =>
                    {
                        TraceManager.WorkerRoleComponent.TraceWarning("******> RETRY LOGIC KICKED IN <******");
                        TraceManager.WorkerRoleComponent.TraceError(ex);
                    };

                    this.interRoleCommunicator = ircComponent;
                }
                else
                {
                    var topicEndpoint = serviceBusSettings.Endpoints.Get(CommonConsts.EventRelayServiceBusEndpointName);

                    this.interRoleCommunicator = new InterRoleEventRelayCommunicationExtension(topicEndpoint);
                }

                int instanceIndex = CommonFuncs.GetRoleInstanceIndex(RoleEnvironment.CurrentRoleInstance.Id);
                bool isFirstInstance = (instanceIndex == 0);

                if (isFirstInstance)
                {
                    var creds = new StorageCredentialsAccountAndKey(storageAccountName, storageAccountKey);
                    var storageAccount = new CloudStorageAccount(creds, true);

                    resultTableStorage = storageAccount.CreateCloudTableClient();
                    resultTableStorage.CreateTableIfNotExist(testResultsTableName);
                    resultTableStorage.CreateTableIfNotExist(testRunsTableName);
                    resultTableStorage.RetryPolicy = RetryPolicies.Retry(RetryPolicies.DefaultClientRetryCount, TimeSpan.FromMilliseconds(100));

                    var ackSubscriber = new UnicastACKSubscriber(interRoleCommunicator, resultTableStorage, testResultsTableName);
                    var startEventSubscriber = new TestRunStartEventSubscriber(interRoleCommunicator, resultTableStorage, testRunsTableName, ackSubscriber);

                    // Register the subscriber for receiving inter-role communication events.
                    this.activeSubscription.Add(this.interRoleCommunicator.Subscribe(ackSubscriber));
                    this.activeSubscription.Add(this.interRoleCommunicator.Subscribe(startEventSubscriber));
                }
                else
                {
                    var ircEventSubscriber = new MulticastEventSubscriber(instanceIndex.ToString(), interRoleCommunicator);

                    // Register the subscriber for receiving inter-role communication events.
                    this.activeSubscription.Add(this.interRoleCommunicator.Subscribe(ircEventSubscriber));
                }
            }
            catch (Exception ex)
            {
                TraceManager.WorkerRoleComponent.TraceError(ex);
                
                RoleEnvironment.RequestRecycle();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Called by Windows Azure when the role instance is to be stopped.
        /// </summary>
        public override void OnStop()
        {
            TraceManager.WorkerRoleComponent.TraceIn();

            if (this.activeSubscription != null)
            {
                foreach (var subscription in activeSubscription)
                {
                    try
                    {
                        subscription.Dispose();
                    }
                    catch
                    {
                        // Must not re-throw.
                    }
                }

                this.activeSubscription.Clear();
            }
            
            if (this.interRoleCommunicator != null)
            {
                // Dispose the IRC component so that it gets a chance to gracefully clean up internal resources.
                this.interRoleCommunicator.Dispose();
                this.interRoleCommunicator = null;
            }

            StopDiagnosticMonitor();
        }

        private void StartDiagnosticMonitor()
        {
            var storageAccount = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccount];
            var storageKey = ConfigurationManager.AppSettings[CommonConsts.ConfigSettingStorageAccountKey];
            var diagnosticConfig = DiagnosticMonitor.GetDefaultInitialConfiguration();
            var diagnosticStorage = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccount, storageKey), true);

            // Configure the scheduled transfer period for all logs.
            diagnosticConfig.DiagnosticInfrastructureLogs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1);
            diagnosticConfig.Logs.ScheduledTransferPeriod = TimeSpan.FromSeconds(10);

            // Configure the logs levels for scheduled transfers.
            diagnosticConfig.DiagnosticInfrastructureLogs.ScheduledTransferLogLevelFilter = LogLevel.Error;
            diagnosticConfig.Logs.ScheduledTransferLogLevelFilter = LogLevel.Undefined;

            this.diagnosticMonitor = DiagnosticMonitor.Start(diagnosticStorage, diagnosticConfig);
        }

        private void StopDiagnosticMonitor()
        {
            if (this.diagnosticMonitor != null)
            {
                try
                {
                    this.diagnosticMonitor.Shutdown();
                }
                catch
                {
                    // Must not re-throw.
                }
            }
        }
    }
}