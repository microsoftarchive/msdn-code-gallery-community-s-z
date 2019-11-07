// -----------------------------------------------------------------------
// <copyright file="ConfigResponse.cs" company="Microsoft">
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
    /// Represents the request object
    /// </summary>
    [DataContract]
    public class ConfigResponse
    {
        /// <summary>
        /// Gets or sets value
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}