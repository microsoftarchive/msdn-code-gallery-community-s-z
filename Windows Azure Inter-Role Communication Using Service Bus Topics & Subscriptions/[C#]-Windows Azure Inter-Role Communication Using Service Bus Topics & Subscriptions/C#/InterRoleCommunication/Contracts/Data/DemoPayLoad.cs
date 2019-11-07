//=======================================================================================
// Microsoft Windows Server AppFabric Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://blogs.msdn.com/appfabriccat/. 
//
//=======================================================================================
// Copyright © 2010 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================


namespace Microsoft.AppFabricCAT.Samples.Azure.InterRoleCommunication.Contracts.Data
{

    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// Represents the payload message that will be used by the ScaleOutCloudDemo project 
    /// </summary>
    [DataContract()]
    public class DemoPayload
    {
        #region Public properties
        /// <summary>
        /// initialized by Publisher before the RUN starts
        /// </summary>
        [DataMember]
        public Guid iterationID { get; set; }
        /// <summary>
        /// initialized by Publisher, before sending to topic
        /// </summary>
        [DataMember]
        public int msgId { get; set; }

        /// <summary>
        /// initialized by Publisher, before sending to topic
        /// Each published msgID should trigger numReceivers * msgID ACKs 
        /// </summary>
        [DataMember]
        public int numReceivers { get; set; }

        /// <summary>
        /// initialized by Publisher, before sending to topic 
        /// </summary>
        [DataMember]
        public DateTime publishTime { get; set; }

        /// <summary>
        /// initialized by Subscriber, before sending back to topic 
        /// </summary>
        [DataMember]
        public DateTime receiveTime { get; set; }

        /// <summary>
        /// initialized by Publisher, on receiving ACK 
        /// </summary>
        [DataMember]
        public DateTime ackReceivedTime { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        [DataMember]
        public long multiCastResponseTime { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        [DataMember]
        public long uniCastResponseTime { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        [DataMember]
        public long totalResponseTime { get; set; }

        /// <summary>
        /// The role instance ID of the sender.
        /// </summary>
        [DataMember]
        public string FromInstanceID { get; set; }

        /// <summary>
        /// The role instance ID of the received.
        /// </summary>
        [DataMember]
        public string ToInstanceID { get; set; }

        #endregion

        #region Constructor
        public DemoPayload(Guid iteration, int msgID, int numRcvrs, DateTime publish)
        {
            iterationID = iteration;
            msgId = msgID;
            numReceivers = numRcvrs;
            publishTime = publish;
        }
        #endregion
    }
}
