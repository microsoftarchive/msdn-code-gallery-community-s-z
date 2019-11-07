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
    /// Implements a configuration section containing Windows Azure Service Bus endpoint configuration settings.
    /// </summary>
    [Serializable]
    public sealed class ServiceBusConfigurationSettings : ConfigurationSection
    {
        #region Private members
        private const string DefaultEndpointProperty = "defaultEndpoint";
        private const string DefaultIssuerNameProperty = "defaultIssuerName";
        private const string DefaultIssuerSecretProperty = "defaultIssuerSecret";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "ServiceBusConfiguration"; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusConfigurationSettings"/> object with default settings.
        /// </summary>
        public ServiceBusConfigurationSettings()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of a Windows Azure Service Bus endpoint which is intended to be used as default.
        /// </summary>
        [ConfigurationProperty(DefaultEndpointProperty, IsRequired = true)]
        public string DefaultEndpoint
        {
            get { return (string)base[DefaultEndpointProperty]; }
            set { base[DefaultEndpointProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the default issuer name for authentication in Windows Azure Service Bus.
        /// </summary>
        [ConfigurationProperty(DefaultIssuerNameProperty, IsRequired = false)]
        public string DefaultIssuerName
        {
            get { return (string)base[DefaultIssuerNameProperty]; }
            set { base[DefaultIssuerNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the default issuer secret for authentication in Windows Azure Service Bus.
        /// </summary>
        [ConfigurationProperty(DefaultIssuerSecretProperty, IsRequired = false)]
        public string DefaultIssuerSecret
        {
            get { return (string)base[DefaultIssuerSecretProperty]; }
            set { base[DefaultIssuerSecretProperty] = value; }
        }

        /// <summary>
        /// Returns a collection of Windows Azure Service Bus endpoints configured for the application.
        /// </summary>
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ServiceBusEndpointInfo))]
        public ServiceBusEndpointCollection Endpoints
        {
            get { return (ServiceBusEndpointCollection)base[String.Empty]; }
        }
        #endregion
    }
}