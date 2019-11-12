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
namespace ScaleOutDemo.WebUI
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    using System.Threading;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Diagnostics;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    #endregion

    public class Global : System.Web.HttpApplication
    {
        private DiagnosticMonitor diagnosticMonitor;
        private readonly ConcurrentDictionary<string, IList<IDisposable>> subscriptions = new ConcurrentDictionary<string, IList<IDisposable>>();

        private static Lazy<IInterRoleCommunicationExtension> ircLazyLoader = new Lazy<IInterRoleCommunicationExtension>(() =>
        {
            var serviceBusSettings = ConfigurationManager.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;
            var topicEndpoint = serviceBusSettings.Endpoints.Get(CommonConsts.TopicServiceBusEndpointName);

            return new InterRoleCommunicationExtension(topicEndpoint);
        }, 
        LazyThreadSafetyMode.ExecutionAndPublication);
        
        public static IInterRoleCommunicationExtension InterRoleCommunicator
        {
            get { return ircLazyLoader.Value; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            StartDiagnosticMonitor();
            TraceManager.WebRoleComponent.TraceInfo("Web Role has successfully initialized and started.");
        }

        void Application_End(object sender, EventArgs e)
        {
            if (InterRoleCommunicator != null)
            {
                InterRoleCommunicator.Dispose();
            }

            StopDiagnosticMonitor();
        }

        void Application_Error(object sender, EventArgs e)
        {
            TraceManager.WebRoleComponent.TraceError(Server.GetLastError());
        }

        void Session_Start(object sender, EventArgs e)
        {
            TraceManager.WebRoleComponent.TraceIn(Session.SessionID);

            subscriptions.AddOrUpdate(Session.SessionID, new List<IDisposable>(), (key, oldValue) => { return oldValue; });

            var sessionSubscriptions = subscriptions[Session.SessionID];
            var finishEventSubscriber = new InterRoleCommunicationEventSubscriber<TestRunFinishEvent>((evt) => 
            {
                TraceManager.WebRoleComponent.TraceInfo("Received TestRunFinishEvent for test run {0}", evt.TestRunID);

                var cache = HttpRuntime.Cache;
                if (cache != null)
                {
                    cache[CommonConsts.SessionKeyTestRunFinishEvent] = evt;
                }
            });

            sessionSubscriptions.Add(InterRoleCommunicator.Subscribe(finishEventSubscriber));

            TraceManager.WebRoleComponent.TraceOut(Session.SessionID);
        }

        void Session_End(object sender, EventArgs e)
        {
            TraceManager.WebRoleComponent.TraceIn(Session.SessionID);

            IList<IDisposable> userSubscriptions = null;

            if (subscriptions.TryGetValue(Session.SessionID, out userSubscriptions))
            {
                foreach (var s in userSubscriptions)
                {
                    s.Dispose();
                }

                subscriptions.TryRemove(Session.SessionID, out userSubscriptions);
            }

            TraceManager.WebRoleComponent.TraceOut(Session.SessionID);
        }

        private void StartDiagnosticMonitor()
        {
            if (CloudEnvironment.IsAvailable)
            {
                using (CloudEnvironment.EnsureSafeHttpContext())
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
            }
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
