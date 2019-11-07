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
    #endregion

    /// <summary>
    /// Represents a custom IRC event that will be used for triggering a test run.
    /// </summary>
    [DataContract]
    public class TestRunStartEvent
    {
        /// <summary>
        /// Defines the number of messages to be pumped through the IRC topic.
        /// </summary>
        [DataMember]
        public int MessageCount { get; set; }

        /// <summary>
        /// Defines the approximate size of a single IRC message.
        /// </summary>
        [DataMember]
        public int MessageSize { get; set; }

        /// <summary>
        /// Defines an unique identity for a test run.
        /// </summary>
        [DataMember]
        public Guid TestRunID { get; set; }

        /// <summary>
        /// A flag indicating whether the event publishing is permitted to be done asynchronously.
        /// </summary>
        [DataMember]
        public bool EnableAsyncPublish { get; set; }

        /// <summary>
        /// A flag indicating whether events should be dispatched to their subscribers immediately as soon as a new event arrives and without waiting until the previous event is processed.
        /// </summary>
        [DataMember]
        public bool EnableAsyncDispatch { get; set; }

        /// <summary>
        /// A flag indicating whether the IRC topic must be cleaned up before a test run starts.
        /// </summary>
        [DataMember]
        public bool RequireTopicCleanup { get; set; }

        /// <summary>
        /// A flag indicating whether the trace log table must be purged before a test run starts.
        /// </summary>
        [DataMember]
        public bool PurgeTraceLogTable { get; set; }
    }
}
