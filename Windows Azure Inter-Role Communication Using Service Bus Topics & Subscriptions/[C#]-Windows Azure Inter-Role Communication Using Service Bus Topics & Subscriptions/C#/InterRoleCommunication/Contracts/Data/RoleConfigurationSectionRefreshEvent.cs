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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data
{
    #region Using references
    using System;
    using System.Runtime.Serialization;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    #endregion

    /// <summary>
    /// Represents an inter-role notification requesting a refresh of the specified configuration section.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    public class RoleConfigurationSectionRefreshEvent
    {
        /// <summary>
        /// The name of the configuration section to be unloaded and re-loaded from the configuration store.
        /// </summary>
        [DataMember]
        public string SectionName { get; private set; }

        /// <summary>
        /// Creates a new instance of the ConfigurationSectionRefresh event for the specified configuration section.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section to be refreshed.</param>
        public RoleConfigurationSectionRefreshEvent(string sectionName)
        {
            SectionName = sectionName;
        }
    }
}
