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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.Collections.Concurrent;

    using Microsoft.ServiceBus;
    #endregion

    /// <summary>
    /// Enables discovering and applying service endpoint configuration at runtime.
    /// </summary>
    public static class ServiceEndpointConfiguration
    {
        #region Private members
        private static readonly BlockingCollection<DiscoveryClientRegistration> discoveryClients = new BlockingCollection<DiscoveryClientRegistration>();
        #endregion

        #region Public members
        public const int DefaultOpenTimeoutSeconds = 60;
        public const int DefaultCloseTimeoutSeconds = 60;
        public const int DefaultReceiveTimeoutSeconds = 60;
        public const int DefaultSendTimeoutSeconds = 60;
        public const int DefaultMaxReceivedMessageSize = Int32.MaxValue;
        public const int DefaultMaxBufferPoolSize = Int32.MaxValue;
        public const int DefaultMaxBufferSize = Int32.MaxValue;
        public const int DefaultReaderQuotasMaxArrayLength = Int32.MaxValue;
        public const int DefaultReaderQuotasMaxBytesPerRead = Int32.MaxValue;
        public const int DefaultReaderQuotasMaxDepth = Int32.MaxValue;
        public const int DefaultReaderQuotasMaxNameTableCharCount = Int32.MaxValue;
        public const int DefaultReaderQuotasMaxStringContentLength = Int32.MaxValue;
        public const TransferMode DefaultTransferMode = TransferMode.Buffered;
        public const TcpRelayConnectionMode DefaultRelayConnectionMode = TcpRelayConnectionMode.Relayed;
        #endregion

        #region Public methods
        public static IDisposable RegisterDiscoveryClient(IObserver<ServiceEndpoint> discoveryClient)
        {
            DiscoveryClientRegistration registration = new DiscoveryClientRegistration(discoveryClient);
            discoveryClients.Add(registration);

            return registration;
        }

        public static void ConfigureDefaults(ServiceEndpoint endpoint)
        {
            Guard.ArgumentNotNull(endpoint, "endpoint");

            // Apply default binding configuration.
            ConfigureDefaults(endpoint.Binding);

            // Notify all registered endpoint configuration discovery clients.
            NotifyDiscoveryClients(endpoint);
        }

        public static void ConfigureDefaults(Binding binding)
        {
            Guard.ArgumentNotNull(binding, "binding");

            // Apply NetOnewayRelayBinding-specific default configuration.
            if (binding is NetOnewayRelayBinding)
            {
                ConfigureDefaults(binding as NetOnewayRelayBinding);
                return;
            }

            // Apply NetTcpRelayBinding-specific default configuration.
            if (binding is NetTcpRelayBinding)
            {
                ConfigureDefaults(binding as NetTcpRelayBinding);
                return;
            }

            // Apply BasicHttpBinding-specific default configuration.
            if (binding is BasicHttpBinding)
            {
                ConfigureDefaults(binding as BasicHttpBinding);
                return;
            }
        }

        public static void ConfigureDefaults(NetOnewayRelayBinding eventRelayBinding)
        {
            Guard.ArgumentNotNull(eventRelayBinding, "eventRelayBinding");

            eventRelayBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            eventRelayBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            eventRelayBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            eventRelayBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            eventRelayBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            eventRelayBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            eventRelayBinding.MaxBufferSize = DefaultMaxBufferSize;

            eventRelayBinding.ReaderQuotas.MaxArrayLength = DefaultReaderQuotasMaxArrayLength;
            eventRelayBinding.ReaderQuotas.MaxBytesPerRead = DefaultReaderQuotasMaxBytesPerRead;
            eventRelayBinding.ReaderQuotas.MaxDepth = DefaultReaderQuotasMaxDepth;
            eventRelayBinding.ReaderQuotas.MaxNameTableCharCount = DefaultReaderQuotasMaxNameTableCharCount;
            eventRelayBinding.ReaderQuotas.MaxStringContentLength = DefaultReaderQuotasMaxStringContentLength;
        }

        public static void ConfigureDefaults(NetTcpRelayBinding relayBinding)
        {
            Guard.ArgumentNotNull(relayBinding, "relayBinding");

            relayBinding.TransferMode = DefaultTransferMode;
            relayBinding.ConnectionMode = DefaultRelayConnectionMode;

            relayBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            relayBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            relayBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            relayBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            relayBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            relayBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            relayBinding.MaxBufferSize = DefaultMaxBufferSize;

            relayBinding.ReaderQuotas.MaxArrayLength = DefaultReaderQuotasMaxArrayLength;
            relayBinding.ReaderQuotas.MaxBytesPerRead = DefaultReaderQuotasMaxBytesPerRead;
            relayBinding.ReaderQuotas.MaxDepth = DefaultReaderQuotasMaxDepth;
            relayBinding.ReaderQuotas.MaxNameTableCharCount = DefaultReaderQuotasMaxNameTableCharCount;
            relayBinding.ReaderQuotas.MaxStringContentLength = DefaultReaderQuotasMaxStringContentLength;
        }

        public static void ConfigureDefaults(BasicHttpBinding httpBinding)
        {
            Guard.ArgumentNotNull(httpBinding, "httpBinding");

            httpBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            httpBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            httpBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            httpBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            httpBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            httpBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            httpBinding.MaxBufferSize = DefaultMaxBufferSize;

            httpBinding.Security.Mode = BasicHttpSecurityMode.None;
            httpBinding.TransferMode = TransferMode.Buffered;
        }
        #endregion

        #region Private methods
        private static void NotifyDiscoveryClients(ServiceEndpoint endpoint)
        {
            foreach (var registration in discoveryClients)
            {
                if (registration.IsActive)
                {
                    registration.Client.OnNext(endpoint);
                }
            }
        }
        #endregion

        #region DiscoveryClientRegistration class declaration
        private class DiscoveryClientRegistration : IDisposable
        {
            private readonly IObserver<ServiceEndpoint> client;
            private volatile bool disposed;

            public DiscoveryClientRegistration(IObserver<ServiceEndpoint> discoveryClient)
            {
                this.client = discoveryClient;
            }

            public bool IsActive
            {
                get { return !this.disposed; }
            }

            public IObserver<ServiceEndpoint> Client
            {
                get { return this.client; }
            }

            public void Dispose()
            {
                this.disposed = true;
            }
        } 
        #endregion
    }
}
