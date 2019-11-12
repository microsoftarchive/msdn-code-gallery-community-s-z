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
    using System.Xml;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;

    using Microsoft.ServiceBus;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    #endregion

    public static class ServiceBusHostFactory
    {
        #region Public methods
        public static ServiceHost CreateServiceBusRelayHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusRelayHost(sbEndpointInfo, typeof(T));
        }

        public static ServiceHost CreateServiceBusRelayHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusRelayHost(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, serviceType);
        }

        public static ServiceHost CreateServiceBusRelayHost<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            return CreateServiceBusRelayHost(serviceNamespace, servicePath, issuerName, issuerSecret, typeof(T));
        }

        public static ServiceHost CreateServiceBusRelayHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Type serviceType)
        {
            var relayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
            return CreateServiceBusHost(serviceNamespace, servicePath, issuerName, issuerSecret, relayBinding, serviceType);
        }

        public static ServiceHost CreateServiceBusEventRelayHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusEventRelayHost<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        public static ServiceHost CreateServiceBusEventRelayHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            return CreateServiceBusEventRelayHost(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, serviceType);
        }

        public static ServiceHost CreateServiceBusEventRelayHost<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            return CreateServiceBusEventRelayHost(serviceNamespace, servicePath, issuerName, issuerSecret, typeof(T));
        }

        public static ServiceHost CreateServiceBusEventRelayHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Type serviceType)
        {
            var eventRelayBinding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
            return CreateServiceBusHost(serviceNamespace, servicePath, issuerName, issuerSecret, eventRelayBinding, serviceType);
        }

        public static ServiceHost CreateServiceBusHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusHost(sbEndpointInfo, typeof(T));
        }

        public static ServiceHost CreateServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(serviceType, "serviceType");

            switch (sbEndpointInfo.EndpointType)
            {
                case ServiceBusEndpointType.Eventing:
                    return CreateServiceBusEventRelayHost(sbEndpointInfo, serviceType);

                case ServiceBusEndpointType.Relay:
                case ServiceBusEndpointType.HybridRelay:
                    return CreateServiceBusRelayHost(sbEndpointInfo, serviceType);

                default:
                    return null;
            }
        } 
        #endregion

        #region Private methods
        private static ServiceHost CreateServiceBusHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding, Type serviceType)
        {
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(servicePath, "servicePath");
            Guard.ArgumentNotNullOrEmptyString(issuerName, "issuerName");
            Guard.ArgumentNotNullOrEmptyString(issuerSecret, "issuerSecret");
            Guard.ArgumentNotNull(binding, "binding");

            var callToken = TraceManager.DebugComponent.TraceIn(serviceNamespace, servicePath, binding.Name);

            var address = ServiceBusEnvironment.CreateServiceUri("sb", serviceNamespace, servicePath);
            var credentialsBehaviour = new TransportClientEndpointBehavior() { TokenProvider = TokenProvider.CreateSharedSecretTokenProvider(issuerName, issuerSecret) };

            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(GetServiceContract(serviceType)), binding, new EndpointAddress(address));
            endpoint.Behaviors.Add(credentialsBehaviour);

            // Apply default endpoint configuration.
            ServiceEndpointConfiguration.ConfigureDefaults(endpoint);

            ServiceBehaviorAttribute serviceBehaviorAttr = FrameworkUtility.GetDeclarativeAttribute<ServiceBehaviorAttribute>(serviceType);
            ServiceHost host = null;

            if (serviceBehaviorAttr != null && serviceBehaviorAttr.InstanceContextMode == InstanceContextMode.Single)
            {
                host = new ServiceHost(Activator.CreateInstance(serviceType));
            }
            else
            {
                host = new ServiceHost(serviceType);
            }

            host.Description.Endpoints.Add(endpoint);
#if DEBUG
            var debugBehavior = new ServiceDebugBehavior();
            debugBehavior.IncludeExceptionDetailInFaults = true;

            host.Description.Behaviors.Remove<ServiceDebugBehavior>();
            host.Description.Behaviors.Add(debugBehavior);
#endif
            TraceManager.DebugComponent.TraceOut(callToken, endpoint.Address.Uri);

            return host;
        }

        public static Type GetServiceContract(Type serviceType)
        {
            Guard.ArgumentNotNull(serviceType, "serviceType");

            Type[] serviceInterfaces = serviceType.GetInterfaces();

            if (serviceInterfaces != null && serviceInterfaces.Length > 0)
            {
                foreach (Type serviceInterface in serviceInterfaces)
                {
                    ServiceContractAttribute serviceContractAttr = FrameworkUtility.GetDeclarativeAttribute<ServiceContractAttribute>(serviceInterface);

                    if (serviceContractAttr != null)
                    {
                        return serviceInterface;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
