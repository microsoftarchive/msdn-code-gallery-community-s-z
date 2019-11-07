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
    /// Represents a custom IRC event that will be triggered when a test run is finished.
    /// </summary>
    [DataContract]
    public class TestRunFinishEvent
    {
        /// <summary>
        /// Defines an unique identity for a test run.
        /// </summary>
        [DataMember]
        public Guid TestRunID { get; set; }

        [DataMember]
        public double Throughput { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }

        [DataMember]
        public long MinUnicastLatency { get; set; }

        [DataMember]
        public double AvgUnicastLatency { get; set; }
        
        [DataMember]
        public long MaxUnicastLatency { get; set; }

        [DataMember]
        public long MinMulticastLatency { get; set; }

        [DataMember]
        public double AvgMulticastLatency { get; set; }

        [DataMember]
        public long MaxMulticastLatency { get; set; }
    }
}
