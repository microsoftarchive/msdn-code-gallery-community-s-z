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
namespace ScaleOutDemo
{
    #region Using references
    using System;
    using System.Text.RegularExpressions;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    #endregion

    public class MulticastEventSubscriber : IObserver<InterRoleCommunicationEvent>
    {
        /// <summary>
        /// RoleID of the subscriber
        /// </summary>
        public string RoleInstanceID { get; set; }

        /// <summary>
        /// Passed in by the instantiator of this class, and is used to Publish the message with ACK
        /// back to the Publisher
        /// </summary>
        private IInterRoleCommunicationExtension interRoleCommunicator;

        public MulticastEventSubscriber(string roleInstanceID, IInterRoleCommunicationExtension communicatorInstance)
        {
            RoleInstanceID = roleInstanceID;
            interRoleCommunicator = communicatorInstance;
        }

        /// <summary>
        /// Receives a notification when a new inter-role communication event occurs.
        /// </summary>
        public void OnNext(InterRoleCommunicationEvent e)
        {
            DemoPayload msg = e.Payload as DemoPayload;

            if (msg != null)
            {
                msg.ReceiveTickCount = HighResolutionTimer.CurrentTickCount;
                msg.ReceiveTime = DateTime.UtcNow;

                // Setup the 'From' & 'To' so that output from Azure storage is easier for debugging
                msg.ToInstanceID = msg.FromInstanceID;
                msg.FromInstanceID = RoleInstanceID;

                // Remove the original payload so that ACKs are not carrying lot more than needed.
                msg.Data = null;

                var response = new InterRoleCommunicationEvent(msg);
            
                // Setting up so that the routing from framework is UniCast
                response.To = e.From;

                interRoleCommunicator.Publish(response);
            }
        }

        /// <summary>
        /// Gets notified that the provider has successfully finished sending notifications to all observers.
        /// </summary>
        public void OnCompleted()
        {
            // Doesn't have to do anything upon completion.
        }

        /// <summary>
        /// Gets notified that the provider has experienced an error condition.
        /// </summary>
        public void OnError(Exception ex)
        {
            // Report on the error through common logging/tracing infrastructure.
            TraceManager.WorkerRoleComponent.TraceError(ex);
        }
    }
}
