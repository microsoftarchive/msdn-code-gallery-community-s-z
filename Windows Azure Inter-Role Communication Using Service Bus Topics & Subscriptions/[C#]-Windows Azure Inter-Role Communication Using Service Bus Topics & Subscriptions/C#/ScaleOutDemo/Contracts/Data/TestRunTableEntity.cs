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

    public class TestRunTableEntity : TableServiceEntity
    {
        /// <summary>
        /// Gets or sets an unique identity for a test run.
        /// </summary>
        public Guid TestRunID { get; set; }

        /// <summary>
        /// Gets or sets the number of messages to be pumped through the IRC topic.
        /// </summary>
        public int MessageCount { get; set; }

        /// <summary>
        /// Gets or sets the approximate size of a single IRC message.
        /// </summary>
        public int MessageSize { get; set; }

        /// <summary>
        /// Gets or sets the number of role instances participating in the test run.
        /// </summary>
        public int InstanceCount { get; set; }

        /// <summary>
        /// Gets or sets a date/time value indicating when a test run has started.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets a date/time value indicating when a test run has been completed.
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets the number of messages processed per second (for completed test runs).
        /// </summary>
        public double Throughput { get; set; }

        public double AvgReqLatency { get; set; }
        public double AvgAckLatency { get; set; }

        public override string PartitionKey
        {
            get
            {
                return this.TestRunID.ToString("N");
            }
            set
            {
            }
        }

        public override string RowKey
        {
            get
            {
                return "";
            }
            set
            {

            }
        }
    }

    public class TestRunEntityTableContext : TableServiceContext
    {
        public string TableName { get; set; }

        public TestRunEntityTableContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<TestRunTableEntity> GetTestRuns()
        {
            return CreateQuery<TestRunTableEntity>(TableName).ToList().OrderByDescending(i => i.StartDateTime).AsQueryable();
        }

        public void AddTestRun(TestRunTableEntity testRun)
        {
            this.AddObject(TableName, testRun);
            this.SaveChangesWithRetries();
        }

        public void UpdateTestRun(TestRunTableEntity testRun)
        {
            if((from e in Entities where e.Entity == testRun select e).Count() > 0)
            {
                Detach(testRun);
                AttachTo(TableName, testRun, "*");
            }
            
            UpdateObject(testRun);
            SaveChangesWithRetries(SaveChangesOptions.ReplaceOnUpdate);
        }
    }
}
