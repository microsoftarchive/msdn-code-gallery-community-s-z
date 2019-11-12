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
    using System.ServiceModel;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    #endregion

    /// <summary>
    /// Represents a generic event for inter-role communication.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    public class InterRoleCommunicationEvent
    {
        #region Public properties
        /// <summary>
        /// Returns the event payload which is a DataContract-serializable object that carries the event's body.
        /// </summary>
        [DataMember]
        public object Payload { get; private set; } 

        /// <summary>
        /// Returns the ID of the event sender.
        /// </summary>
        [DataMember]
        public string From { get; internal set; }

        /// <summary>
        /// Gets or sets the ID of the event receiver.
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// Returns a collection of custom properties associated with the event.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Properties { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the multicast inter-role communication event with the specified payload.
        /// </summary>
        /// <param name="payload">The event payload.</param>
        public InterRoleCommunicationEvent(object payload)
        {
            From = FrameworkUtility.GetHashedValue(CloudEnvironment.DeploymentId, CloudEnvironment.CurrentRoleInstanceId);
            Properties = new Dictionary<string, object>();
            Payload = payload;
        }

        /// <summary>
        /// Creates a new instance of the inter-role communication event with the specified payload and deployment ID, role name and role instance ID that identify the recipient.
        /// </summary>
        /// <param name="payload">The event payload.</param>
        /// <param name="deploymentID">The deployment ID identifying a hosted service in which the recipients for the inter-role communication event are deployed.</param>
        /// <param name="roleName">The name identifying a role to which inter-role communication event recipient belong.</param>
        /// <param name="roleInstanceID">The role instance ID uniquely identifying a particular recipient of the inter-role communication event.</param>
        public InterRoleCommunicationEvent(object payload, string deploymentID = null, string roleName = null, string roleInstanceID = null) : this(payload)
        {
            // Check of role instance ID was specified. 
            if (!String.IsNullOrEmpty(roleInstanceID))
            {
                // If role instance ID is specified, use a combination of deployment ID and role instance ID to determine where to send.
                To = FrameworkUtility.GetHashedValue(deploymentID ?? CloudEnvironment.DeploymentId, roleInstanceID);
            }
            else if (!String.IsNullOrEmpty(roleName))
            { 
                // If role instance ID is not provided but name was specified instead, assume that the event is to be sent to all instances of a particular role.
                To = FrameworkUtility.GetHashedValue(deploymentID ?? CloudEnvironment.DeploymentId, roleName);
            }
            // Otherwise, treat this event as a multicast event and do not set the To property.
        }
        #endregion
    }
}
