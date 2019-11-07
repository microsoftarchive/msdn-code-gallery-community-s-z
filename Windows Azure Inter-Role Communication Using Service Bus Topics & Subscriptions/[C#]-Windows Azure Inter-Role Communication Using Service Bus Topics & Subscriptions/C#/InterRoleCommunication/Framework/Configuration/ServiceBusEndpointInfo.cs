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
    using System.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration element describing a Windows Azure Service Bus endpoint.
    /// </summary>
    public sealed class ServiceBusEndpointInfo : ConfigurationElement
    {
        #region Private members
        private const string NameProperty = "name";
        private const string ServicePathProperty = "servicePath";
        private const string ServiceNamespaceProperty = "serviceNamespace";
        private const string EndpointTypeProperty = "endpointType";
        private const string IssuerNameProperty = "issuerName";
        private const string IssuerSecretProperty = "issuerSecret";
        private const string TopicNameProperty = "topicName";
        private const string QueueNameProperty = "queueName";
        private const string SubscriptionNameProperty = "subscriptionName";
        #endregion

        #region Constructors
        public ServiceBusEndpointInfo() : base()
        {
        }

        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath) : this(endpointName, serviceNamespace, servicePath, null, null)
        {
        }

        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
            : this(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Relay)
        {
        }

        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret, ServiceBusEndpointType endpointType)
            : this()
        {
            Guard.ArgumentNotNullOrEmptyString(endpointName, "endpointName");
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(servicePath, "servicePath");

            Name = endpointName;
            ServiceNamespace = serviceNamespace;
            ServicePath = servicePath;
            IssuerName = issuerName;
            IssuerSecret = issuerSecret;
            EndpointType = endpointType;
        }
        #endregion

        #region Public properties
        [ConfigurationProperty(NameProperty, IsRequired = true)]
        public string Name
        {
            get { return (string)base[NameProperty]; }
            set { base[NameProperty] = value; }
        }

        [ConfigurationProperty(ServiceNamespaceProperty, IsRequired = true)]
        public string ServiceNamespace
        {
            get { return (string)base[ServiceNamespaceProperty]; }
            set { base[ServiceNamespaceProperty] = value; }
        }

        [ConfigurationProperty(ServicePathProperty, IsRequired = false)]
        public string ServicePath
        {
            get { return (string)base[ServicePathProperty]; }
            set { base[ServicePathProperty] = value; }
        }

        [ConfigurationProperty(IssuerNameProperty, IsRequired = false)]
        public string IssuerName
        {
            get { return (string)base[IssuerNameProperty]; }
            set { base[IssuerNameProperty] = value; }
        }

        [ConfigurationProperty(IssuerSecretProperty, IsRequired = false)]
        public string IssuerSecret
        {
            get { return (string)base[IssuerSecretProperty]; }
            set { base[IssuerSecretProperty] = value; }
        }

        [ConfigurationProperty(TopicNameProperty, IsRequired = false)]
        public string TopicName
        {
            get { return (string)base[TopicNameProperty]; }
            set { base[TopicNameProperty] = value; }
        }

        [ConfigurationProperty(QueueNameProperty, IsRequired = false)]
        public string QueueName
        {
            get { return (string)base[QueueNameProperty]; }
            set { base[QueueNameProperty] = value; }
        }

        [ConfigurationProperty(SubscriptionNameProperty, IsRequired = false)]
        public string SubscriptionName
        {
            get { return (string)base[SubscriptionNameProperty]; }
            set { base[SubscriptionNameProperty] = value; }
        }

        [ConfigurationProperty(EndpointTypeProperty, IsRequired = true)]
        public ServiceBusEndpointType EndpointType
        {
            get { return (ServiceBusEndpointType)base[EndpointTypeProperty]; }
            set { base[EndpointTypeProperty] = value; }
        }
        #endregion
    }
}
