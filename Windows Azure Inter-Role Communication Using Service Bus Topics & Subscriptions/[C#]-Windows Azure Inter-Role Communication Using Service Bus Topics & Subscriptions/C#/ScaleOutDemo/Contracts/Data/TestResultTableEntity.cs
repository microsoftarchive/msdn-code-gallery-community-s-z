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
namespace ScaleOutDemo.Contracts.Data
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Data.Services.Client;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    #endregion

    public class TestResultTableEntity : TableServiceEntity
    {
        #region Public properties
        /// <summary>
        /// initialized by Publisher before the RUN starts
        /// </summary>
        public Guid IterationID { get; set; }

        /// <summary>
        /// initialized by Publisher, before sending to topic
        /// </summary>
        public int MsgId { get; set; }

        // <summary>
        /// The role instance ID of the sender.
        /// </summary>
        public string FromInstanceID { get; set; }

        /// <summary>
        /// Initialized by Subscriber, before sending back to topic.
        /// </summary>
        public DateTime ReceiveTime { get; set; }

        /// <summary>
        /// Initialized by Subscriber, before sending back to topic.
        /// </summary>
        public long ReceiveTickCount { get; set; }

        /// <summary>
        /// initialized by Publisher, before sending to topic 
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// Initialized by Publisher before sending to topic.
        /// </summary>
        public long PublishTickCount { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        public long MulticastResponseTime { get; set; }

        /// <summary>
        /// initialized by Publisher, before sending to topic
        /// Each published msgID should trigger numReceivers * msgID ACKs 
        /// </summary>
        public int NumReceivers { get; set; }

        /// <summary>
        /// initialized by Publisher, on receiving ACK 
        /// </summary>
        public DateTime AckReceivedTime { get; set; }

        /// <summary>
        /// Initialized by Publisher on receiving ACK.
        /// </summary>
        public long AckReceivedTickCount { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        public long UnicastResponseTime { get; set; }

        /// <summary>
        /// computed by Publisher, before sending to storage 
        /// </summary>
        public long TotalResponseTime { get; set; }

        /// <summary>
        /// The role instance ID of the received.
        /// </summary>
        public string ToInstanceID { get; set; }
        #endregion

        public override string PartitionKey
        {
            get
            {
                return this.IterationID.ToString("N");
            }
            set
            {

            }

        }

        public override string RowKey
        {
            get
            {
                return String.Concat(this.MsgId, this.FromInstanceID);
            }
            set
            {

            }
        }
    }


    public class TestResultEntityTableContext : TableServiceContext
    {
        public string TableName { get; set; }

        public TestResultEntityTableContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<TestResultTableEntity> DemoTestResults
        {
            get
            {
                return CreateQuery<TestResultTableEntity>(TableName);
            }
        }

         

        public void AddResults(TestResultTableEntity results)
        {
            AddObject(TableName, results);
            SaveChangesWithRetries();
        }

        public void UpdateResults(TestResultTableEntity results)
        {
            if ((from e in Entities where e.Entity == results && e.State == EntityStates.Added select e).Count() > 0)
            {
                Detach(results);
                AttachTo(TableName, results, "*");
            }

            UpdateObject(results);
            SaveChangesWithRetries(SaveChangesOptions.ReplaceOnUpdate);
        }
    }
}
