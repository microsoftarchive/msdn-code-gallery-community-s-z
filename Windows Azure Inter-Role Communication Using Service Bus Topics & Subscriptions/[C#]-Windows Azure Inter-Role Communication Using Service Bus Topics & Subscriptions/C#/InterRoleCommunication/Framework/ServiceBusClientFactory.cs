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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;

    using Microsoft.ServiceBus;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    #endregion

    public static class ServiceBusClientFactory
    {
        #region Public methods
        public static T CreateServiceBusRelayClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T: IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusRelayClient<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        public static T CreateServiceBusRelayClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret) where T : IClientChannel
        {
            var relayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
            return CreateServiceBusClient<T>(serviceNamespace, servicePath, issuerName, issuerSecret, relayBinding);
        }

        public static T CreateServiceBusEventRelayClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusEventRelayClient<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        public static T CreateServiceBusEventRelayClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret) where T : IClientChannel
        {
            var eventRelayBinding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
            return CreateServiceBusClient<T>(serviceNamespace, servicePath, issuerName, issuerSecret, eventRelayBinding);
        }

        public static T CreateServiceBusClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            ChannelFactory<T> clientChannelFactory = CreateServiceBusClientChannelFactory<T>(sbEndpointInfo);
            return clientChannelFactory.CreateChannel();
        }

        public static ChannelFactory<T> CreateServiceBusClientChannelFactory<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            Binding binding = null;

            switch (sbEndpointInfo.EndpointType)
            {
                case ServiceBusEndpointType.Eventing:

                    binding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
                    break;

                case ServiceBusEndpointType.Relay:
                case ServiceBusEndpointType.HybridRelay:

                    NetTcpRelayBinding tcpRelayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
                    tcpRelayBinding.ConnectionMode = (sbEndpointInfo.EndpointType == ServiceBusEndpointType.HybridRelay ? TcpRelayConnectionMode.Hybrid : TcpRelayConnectionMode.Relayed);

                    binding = tcpRelayBinding;
                    break;

                default:
                    return null;
            }

            return CreateServiceBusClientChannelFactory<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, binding);
        }
        #endregion

        #region Private methods
        private static T CreateServiceBusClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding)
        {
            ChannelFactory<T> clientChannelFactory = CreateServiceBusClientChannelFactory<T>(serviceNamespace, servicePath, issuerName, issuerSecret, binding);
            return clientChannelFactory.CreateChannel();
        }

        private static ChannelFactory<T> CreateServiceBusClientChannelFactory<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding)
        {
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(servicePath, "servicePath");
            Guard.ArgumentNotNullOrEmptyString(issuerName, "issuerName");
            Guard.ArgumentNotNullOrEmptyString(issuerSecret, "issuerSecret");
            Guard.ArgumentNotNull(binding, "binding");

            var callToken = TraceManager.DebugComponent.TraceIn(serviceNamespace, servicePath, binding.Name);

            var address = ServiceBusEnvironment.CreateServiceUri("sb", serviceNamespace, servicePath);
            var credentialsBehaviour = new TransportClientEndpointBehavior() { TokenProvider = TokenProvider.CreateSharedSecretTokenProvider(issuerName, issuerSecret) };
            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(T)), binding, new EndpointAddress(address));

            endpoint.Behaviors.Add(credentialsBehaviour);

            // Apply default endpoint configuration.
            ServiceEndpointConfiguration.ConfigureDefaults(endpoint);

            ChannelFactory<T> clientChannelFactory = new ChannelFactory<T>(endpoint);

            TraceManager.DebugComponent.TraceOut(callToken, endpoint.Address.Uri);

            return clientChannelFactory;
        }
        #endregion
    }
}