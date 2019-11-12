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

    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Messaging.Filters;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    #endregion

    /// <summary>
    /// Provides value-add extension methods for Windows Azure Service Bus entities such as topics, queues and subscriptions.
    /// </summary>
    public static class ServiceBusEntityExtensionMethods
    {
        public static void Complete(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Complete(); });
        }

        public static void Abandon(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Abandon(); });
        }

        public static void Defer(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Defer(); });
        }

        public static void DeadLetter(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.DeadLetter(); });
        }
    }
}
