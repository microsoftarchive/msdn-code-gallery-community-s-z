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

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    #endregion

    /// <summary>
    /// Defines runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
    /// </summary>
    public class InterRoleCommunicationSettings
    {
        /// <summary>
        /// Defines the maximum lock duration allowed by messaging service.
        /// </summary>
        private static readonly TimeSpan MaximumLockDuration = TimeSpan.FromMinutes(5.0);

        /// <summary>
        /// Allows specifying a custom time value indicating how long Service Bus messaging API will keep a communication channel open while waiting for a new event.
        /// </summary>
        public TimeSpan EventWaitTimeout { get; set; }

        /// <summary>
        /// Allows specifying a custom time-to-live (TTL) value for inter-role communication events. Events older than their TTL will be removed before they can reach the subscribers.
        /// </summary>
        public TimeSpan EventTimeToLive { get; set; }

        /// <summary>
        /// Allows specifying a custom duration in which the inter-role communication events that are being processed remain marked as “in-flight” and invisible to other competing consumers (if any).
        /// </summary>
        public TimeSpan EventLockDuration { get; set; }

        /// <summary>
        /// Enables the publishing role instances to receive their own events as carbon copies.
        /// </summary>
        public bool EnableCarbonCopy { get; set; }

        /// <summary>
        /// Enables publishing the inter-role communication events in an asynchronous, non-blocking fashion without having to wait until events are put into a topic.
        /// </summary>
        public bool EnableAsyncPublish { get; set; }

        /// <summary>
        /// Enables dispatching the inter-role communication events to their subscribers immediately as soon as a new event arrives and without waiting until the previous event is processed.
        /// </summary>
        public bool EnableAsyncDispatch { get; set; }

        /// <summary>
        /// Enables dispatching the inter-role communication events to multiple subscribers in parallel without serializing execution of subscribers.
        /// </summary>
        public bool EnableParallelDispatch { get; set; }

        /// <summary>
        /// Enables multiple role instances to receive the inter-role communication events from the same subscription with the guarantee that each event is consumed only by one of the role instances.
        /// </summary>
        public bool UseCompetingConsumers { get; set; }

        /// <summary>
        /// Returns a retry policy that will be used for ensuring reliable access to the underlying messaging infrastructure.
        /// </summary>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterRoleCommunicationSettings"/> object using default settings.
        /// </summary>
        public InterRoleCommunicationSettings()
        {
            EventWaitTimeout = TimeSpan.FromSeconds(30);
            EventTimeToLive = TimeSpan.FromMinutes(10);
            EventLockDuration = MaximumLockDuration;
            EnableCarbonCopy = false;
            EnableAsyncPublish = false;
            EnableAsyncDispatch = true;
            EnableParallelDispatch = true;
            UseCompetingConsumers = false;
            RetryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount);
        }

        /// <summary>
        /// Returns default runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
        /// </summary>
        public static InterRoleCommunicationSettings Default
        {
            get { return new InterRoleCommunicationSettings(); }
        }
    }
}
