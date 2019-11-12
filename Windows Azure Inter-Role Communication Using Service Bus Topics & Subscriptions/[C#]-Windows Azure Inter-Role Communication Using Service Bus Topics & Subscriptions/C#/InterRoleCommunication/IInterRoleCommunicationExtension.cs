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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication
{
    #region Using references
    using System;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a generic contract for inter-role communication mechanism using publish/subscribe messaging infrastructure.
    /// </summary>
    public interface IInterRoleCommunicationExtension : IObservable<InterRoleCommunicationEvent>, IObservable<Tuple<Exception, InterRoleCommunicationEvent>>, IDisposable
    {
        /// <summary>
        /// Publishes the specified inter-role communication event to one or more subscribers.
        /// </summary>
        /// <param name="e">The inter-role communication event to be delivered to the subscribers.</param>
        void Publish(InterRoleCommunicationEvent e);
    }
}
