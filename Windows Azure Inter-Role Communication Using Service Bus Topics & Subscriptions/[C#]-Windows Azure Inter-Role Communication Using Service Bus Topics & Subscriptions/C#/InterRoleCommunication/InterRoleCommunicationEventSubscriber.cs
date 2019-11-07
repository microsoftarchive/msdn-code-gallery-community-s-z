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
    using System.ServiceModel;
    using System.Diagnostics;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    #endregion

    /// <summary>
    /// Provides a generic subscriber for inter-role communication (IRC) events of the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the inter-role communication event which this subscriber intends to handle.</typeparam>
    public abstract class InterRoleCommunicationEventSubscriberBase<T> : IObserver<InterRoleCommunicationEvent> where T: class
    {
        #region IObserver<InterRoleCommunicationEvent> implementation
		/// <summary>
        /// Receives a notification when a new inter-role communication event occurs.
		/// </summary>
        /// <param name="e">The instance of the inter-role communication event received from the underlying messaging system.</param>
        void IObserver<InterRoleCommunicationEvent>.OnNext(InterRoleCommunicationEvent e)
        {
            if (e != null && e.Payload != null)
            {
                T payload = e.Payload as T;

                if (payload != null)
                {
                    OnNext(payload);
                }
            }
        }

        /// <summary>
        /// Gets notified that the IRC messaging component has successfully finished notifying all subscribers.
        /// </summary>
        void IObserver<InterRoleCommunicationEvent>.OnCompleted()
        {
            OnCompleted();
        }

        /// <summary>
        /// Gets notified that the IRC messaging component has experienced an error condition.
        /// </summary>
        /// <param name="error">The original exception that has resulted in the error condition.</param>
        void IObserver<InterRoleCommunicationEvent>.OnError(Exception error)
        {
            // Report on the error through default logging/tracing infrastructure.
            OnError(error);
        } 
	    #endregion

        /// <summary>
        /// Receives a notification when a new inter-role communication event of type <typeparamref name="T"/> occurs.
        /// </summary>
        /// <param name="e"></param>
        public abstract void OnNext(T e);

        /// <summary>
        /// Gets notified that the IRC component has successfully finished notifying all observers.
        /// </summary>
        public abstract void OnCompleted();

        /// <summary>
        /// Gets notified that the IRC component has experienced an error condition.
        /// </summary>
        /// <param name="error"></param>
        public abstract void OnError(Exception error);
    }

    /// <summary>
    /// Implements a generic subscriber for inter-role communication (IRC) events of type <typeparamref name="T"/> with customizable subscribe, completion and fault handling actions.
    /// </summary>
    /// <typeparam name="T">The type of the inter-role communication event which this subscriber intends to handle.</typeparam>
    public class InterRoleCommunicationEventSubscriber<T> : InterRoleCommunicationEventSubscriberBase<T> where T : class
    {
        #region Private members
        private Action<T> subscribeAction;
        private Action completeAction;
        private Action<Exception> faultAction;
        #endregion

        public InterRoleCommunicationEventSubscriber(Action<T> subscribeAction, Action completeAction = null, Action<Exception> faultAction = null)
        {
            Guard.ArgumentNotNull(subscribeAction, "subscribeAction");

            this.subscribeAction = subscribeAction;
            this.completeAction = completeAction;
            this.faultAction = faultAction;
        }

        /// <summary>
        /// Receives a notification when a new inter-role communication event of type <typeparamref name="T"/> occurs.
        /// </summary>
        /// <param name="e">The instance of the inter-role communication event received from the underlying messaging system.</param>
        public override void OnNext(T e)
        {
            this.subscribeAction(e);
        }

        /// <summary>
        /// Gets notified that the IRC messaging component has successfully finished notifying all subscribers.
        /// </summary>
        public override void OnCompleted()
        {
            if (this.completeAction != null)
            {
                this.completeAction();
            }
        }

        /// <summary>
        /// Gets notified that the IRC messaging component has experienced an error condition.
        /// </summary>
        /// <param name="error">The original exception that has resulted in the error condition.</param>
        public override void OnError(Exception error)
        {
            if (this.faultAction != null)
            {
                this.faultAction(error);
            }
        }
    }
}
