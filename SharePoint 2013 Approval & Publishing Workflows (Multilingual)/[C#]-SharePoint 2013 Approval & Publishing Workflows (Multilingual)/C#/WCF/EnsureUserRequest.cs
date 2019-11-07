// -----------------------------------------------------------------------
// <copyright file="WorkflowServiceRequest.cs" company="Microsoft">
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
    public class EnsureUserRequestResponse
    {
        /// <summary>
        /// Gets or sets List of users
        /// </summary>
        [DataMember]
        public List<User> Users { get; set; }
    }
}
