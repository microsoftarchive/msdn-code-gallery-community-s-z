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
    using System.Globalization;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Services;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    #endregion

    /// <summary>
    /// Implements a role extension which provides access to the inter-role communication service
    /// and enables registering subscriptions for inter-role communication events.
    /// </summary>
    public class InterRoleEventRelayCommunicationExtension : IInterRoleCommunicationExtension
    {
        #region Private members
        private readonly object subscriberLock = new object();
        private readonly object publisherLock = new object();
        private readonly ServiceBusEndpointInfo serviceBusEndpoint;

        private ReliableServiceBusClient<IInterRoleCommunicationServiceChannel> publisher;
        private ReliableServiceBusHost<InterRoleCommunicationService> subscriber;
        private bool disposed;
        #endregion

        #region Constructor
        public InterRoleEventRelayCommunicationExtension(ServiceBusEndpointInfo serviceBusEndpoint)
        {
            Guard.ArgumentNotNull(serviceBusEndpoint, "serviceBusEndpoint");

            this.serviceBusEndpoint = serviceBusEndpoint;

            // Open a WCF service host servicing the IInterRoleCommunicationService contract.
            Subscriber.Open();
        }
        #endregion

        #region IInterRoleCommunicationExtension implementation
        /// <summary>
        /// Publishes the specified inter-role communication event into publish/subscribe messaging infrastructure.
        /// </summary>
        /// <param name="e">The inter-role communication event to be published.</param>
        public void Publish(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

            // Wrap a call to the Publish into a retry policy-aware scope. This is because NetEventRelayBinding may return a fault if there are no 
            // subscribers listening on the Service Bus URI. This behavior may be changed in the future releases of the Service Bus.
            Publisher.RetryPolicy.ExecuteAction(() =>
            {
                Publisher.Client.Publish(e);
            });
        }

        /// <summary>
        ///  Registers the specified subscriber to receive inter-role communication events.
        /// </summary>
        /// <param name="subscriber">The object that is to receive notifications.</param>
        /// <returns>The observer's interface that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<InterRoleCommunicationEvent> subscriber)
        {
            return Subscriber.ServiceInstance.Subscribe(subscriber);
        }

        public IDisposable Subscribe(IObserver<Tuple<Exception, InterRoleCommunicationEvent>> observer)
        {
            return Subscriber.ServiceInstance.Subscribe(observer);
        }
        #endregion

        #region Private properties & methods
        private ReliableServiceBusClient<IInterRoleCommunicationServiceChannel> Publisher
        {
            get
            {
                if (null == this.publisher)
                {
                    lock (this.publisherLock)
                    {
                        if (null == this.publisher)
                        {
                            RetryPolicy serviceBusRetryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount);

                            this.publisher = new ReliableServiceBusClient<IInterRoleCommunicationServiceChannel>(this.serviceBusEndpoint, serviceBusRetryPolicy);
                        }
                    }
                }

                Guard.ArgumentNotNull(this.publisher, "publisher");
                return this.publisher;
            }
        }

        private ReliableServiceBusHost<InterRoleCommunicationService> Subscriber
        {
            get
            {
                if (null == this.subscriber)
                {
                    lock (this.subscriberLock)
                    {
                        if (null == this.subscriber)
                        {
                            RetryPolicy serviceBusRetryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount);

                            this.subscriber = new ReliableServiceBusHost<InterRoleCommunicationService>(this.serviceBusEndpoint, serviceBusRetryPolicy);
                        }
                    }
                }

                Guard.ArgumentNotNull(this.subscriber, "subscriber");
                return this.subscriber;
            }
        }
        #endregion

        #region IDisposable implementation
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        if (this.subscriber != null)
                        {
                            this.subscriber.Dispose();
                            this.subscriber = null;
                        }
                    }
                    catch
                    {
                        // Do not let the code to fail on disposal.
                    }

                    try
                    {
                        if (this.publisher != null)
                        {
                            this.publisher.Dispose();
                            this.publisher = null;
                        }
                    }
                    catch
                    {
                        // Do not let the code to fail on disposal.
                    }

                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~InterRoleEventRelayCommunicationExtension()
        {
            this.Dispose(false);
        }
        #endregion
    }
}