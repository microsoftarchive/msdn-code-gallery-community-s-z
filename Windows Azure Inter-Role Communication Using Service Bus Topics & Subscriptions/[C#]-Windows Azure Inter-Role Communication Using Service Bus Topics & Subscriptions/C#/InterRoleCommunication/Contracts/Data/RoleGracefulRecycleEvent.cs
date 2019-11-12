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
    /// Represents an inter-role notification requesting a graceful recycle of all instances of a particular role.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    public class RoleGracefulRecycleEvent
    {
        /// <summary>
        /// The name of the role the instances of which are being asked to recycle themselves gracefully.
        /// </summary>
        [DataMember]
        public string RoleName { get; private set; }

        /// <summary>
        /// Creates a new instance of the RoleGracefulRecycle event for the specified role.
        /// </summary>
        /// <param name="roleName">The name of the role the instances of which are being asked to recycle themselves gracefully.</param>
        public RoleGracefulRecycleEvent(string roleName)
        {
            RoleName = roleName;
        }
    }
}
