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
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.Collections.Generic;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Services;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Implements the contact for inter-role communication using push-based notifications.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public sealed class InterRoleCommunicationService : IInterRoleCommunicationServiceContract
    {
        #region Private members
        /// <summary>
        /// The collection of registered subscribers. When a subscriber deactivates its subscription, it will be removed from the collection.
        /// </summary>
        private readonly IList<IObserver<InterRoleCommunicationEvent>> subscribers = new List<IObserver<InterRoleCommunicationEvent>>();
        #endregion

        #region IInterRoleCommunicationServiceContract implementation
        /// <summary>
        /// Multicasts the specified inter-role communication event to one or more subscribers.
        /// </summary>
        /// <param name="e">The inter-role communication event to be delivered to the subscribers.</param>
        public void Publish(InterRoleCommunicationEvent e)
        {
            // Validate input parameters.
            Guard.ArgumentNotNull(e, "e");

            // Log an entry point.
            var callToken = TraceManager.ServiceComponent.TraceIn(e.From);

            try
            {
                // Query all registered subscribers using query parallelization provided by PLINQ.
                var subscribers = from s in this.subscribers.AsParallel().AsUnordered() select s;

                // Invokes the specified action for each subscriber.
                subscribers.ForAll((subscriber) =>
                {
                    try
                    {
                        // Notify the subscriber.
                        subscriber.OnNext(e);
                    }
                    catch (Exception ex)
                    {
                        // Do not allow any subscriber to generate a fault and affect other subscribers.
                        try
                        {
                            // Notifies the subscriber that the event provider has experienced an error condition.
                            subscriber.OnError(ex);
                        }
                        catch (Exception fault)
                        {
                            // Log an error.
                            TraceManager.ServiceComponent.TraceError(fault);
                        }
                    }
                });
            }
            finally
            {
                // Log an exit point.
                TraceManager.ServiceComponent.TraceOut(callToken);
            }
        }

        public void Dispose()
        {
            subscribers.Clear();
        }
        #endregion

        #region IObservable implementation
        /// <summary>
        ///  Registers the specified subscriber to receive inter-role communication events.
        /// </summary>
        /// <param name="subscriber">The object that is to receive notifications.</param>
        /// <returns>The observer's interface that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<InterRoleCommunicationEvent> subscriber)
        {
            // Before registering a subscriber, verify whether or not it has already been registered. This is to prevent duplicate notifications.
            if (!this.subscribers.Contains(subscriber))
            {
                this.subscribers.Add(subscriber);
            }

            // Return a special object that provides the ability to cancel this subscription.
            return new UnsubscribeCallback(subscribers, subscriber);
        }

        /// <summary>
        /// Registers the specified subscriber to receive notifications when inter-role communication events fail to have been processed asynchronously.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <returns>The instance of an object that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<Tuple<Exception, InterRoleCommunicationEvent>> observer)
        {
            // TODO
            throw new NotImplementedException();
        }
        #endregion

        #region UnsubscribeCallback implementation
        /// <summary>
        /// Internal implementation of the subscription cancellation object.
        /// </summary>
        private class UnsubscribeCallback : IDisposable
        {
            private IList<IObserver<InterRoleCommunicationEvent>> subscribers;
            private IObserver<InterRoleCommunicationEvent> subscriber;

            public UnsubscribeCallback(IList<IObserver<InterRoleCommunicationEvent>> subscribers, IObserver<InterRoleCommunicationEvent> subscriber)
            {
                this.subscribers = subscribers;
                this.subscriber = subscriber;
            }

            public void Dispose()
            {
                if (this.subscribers != null && this.subscriber != null && this.subscribers.Contains(this.subscriber))
                {
                    this.subscribers.Remove(this.subscriber);
                }
            }
        }
        #endregion
    }
}