// -----------------------------------------------------------------------
// <copyright file="WorkflowItemInfo.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation &amp;.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomApprovalWorkflows.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the request and Response object
    /// </summary>
    [DataContract]
    public class WorkflowItemInfo
    {
        /// <summary>
        /// Gets or sets List Id
        /// </summary>
        [DataMember]
        public Guid ListId { get; set; }

        /// <summary>
        /// Gets or sets Item Id
        /// </summary>
        [DataMember]
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets workflow instance Id
        /// </summary>
        [DataMember]
        public Guid WorkflowInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [DataMember]
        public string Status { get; set; }
    }
}
