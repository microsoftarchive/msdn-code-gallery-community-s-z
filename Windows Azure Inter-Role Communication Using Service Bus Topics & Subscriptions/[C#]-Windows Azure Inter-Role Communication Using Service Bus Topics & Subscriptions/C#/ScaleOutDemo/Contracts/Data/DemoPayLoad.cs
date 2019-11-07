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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    #endregion

    /// <summary>
    /// Represents the payload message that will be used by the ScaleOutCloudDemo project.
    /// </summary>
    [DataContract]
    public class DemoPayload
    {
        #region Public properties
        /// <summary>
        /// Initialized by Publisher before the RUN starts.
        /// </summary>
        [DataMember]
        public Guid IterationID { get; set; }

        /// <summary>
        /// Initialized by Publisher before sending to topic.
        /// </summary>
        [DataMember]
        public int MsgId { get; set; }

        /// <summary>
        /// Initialized by Publisher, before sending to topic. 
        /// Each published msgID should trigger numReceivers * msgID ACKs 
        /// </summary>
        [DataMember]
        public int NumReceivers { get; set; }

        /// <summary>
        /// Initialized by Publisher before sending to topic.
        /// </summary>
        [DataMember]
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// Initialized by Publisher before sending to topic.
        /// </summary>
        [DataMember]
        public long PublishTickCount { get; set; }

        /// <summary>
        /// Initialized by Subscriber before sending an ACK back to topic.
        /// </summary>
        [DataMember]
        public DateTime ReceiveTime { get; set; }

        /// <summary>
        /// Initialized by Subscriber before sending an ACK back to topic.
        /// </summary>
        [DataMember]
        public long ReceiveTickCount { get; set; }

        /// <summary>
        /// Initialized by Publisher on receiving ACK.
        /// </summary>
        [DataMember]
        public DateTime AckReceivedTime { get; set; }

        /// <summary>
        /// Initialized by Publisher on receiving ACK.
        /// </summary>
        [DataMember]
        public long AckReceivedTickCount { get; set; }

        /// <summary>
        /// Computed by Publisher before sending to storage.
        /// </summary>
        [DataMember]
        public long MulticastResponseTime { get; set; }

        /// <summary>
        /// Computed by Publisher before sending to storage.
        /// </summary>
        [DataMember]
        public long UnicastResponseTime { get; set; }

        /// <summary>
        /// Computed by Publisher, before sending to storage.
        /// </summary>
        [DataMember]
        public long TotalResponseTime { get; set; }

        /// <summary>
        /// Tracks the sender role ID within the payload for easier debugging from Azure Storage.
        /// </summary>
        [DataMember]
        public string FromInstanceID { get; set; }

        /// <summary>
        /// Tracks the receiver role ID within the payload for easier debugging from Azure Storage
        /// </summary>
        [DataMember]
        public string ToInstanceID { get; set; }

        /// <summary>
        /// Represents the data portion of the message which is used for adjusting the size of the messages being sent via Service Bus.
        /// </summary>
        [DataMember]
        public byte[] Data { get; set; }
        #endregion

        #region Constructor
        public DemoPayload(Guid iteration, int msgID, int numRcvrs, DateTime publish)
        {
            IterationID = iteration;
            MsgId = msgID;
            NumReceivers = numRcvrs;
            PublishTime = publish;
        }
        #endregion
    }
}
