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
    using System.ComponentModel;
    #endregion

    [DefaultValue(ServiceBusEndpointType.Relay)]
    public enum ServiceBusEndpointType
    {
        /// <summary>
        /// Defines the usage of the NetTcpRelayBinding binding with Relayed connection mode.
        /// </summary>
        Relay,

        /// <summary>
        /// Defines the usage of the NetTcpRelayBinding binding with Hybrid connection mode.
        /// </summary>
        HybridRelay,

        /// <summary>
        /// Defines the usage of the NetEventRelayBinding binding.
        /// </summary>
        Eventing,

        /// <summary>
        /// Defines the usage of the Service Bus queues.
        /// </summary>
        Queue,

        /// <summary>
        /// Defines the usage of the Service Bus topics.
        /// </summary>
        Topic
    }
}
