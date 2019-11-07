// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Microsoft">
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
    /// Represents the User
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        [DataMember]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the UPN
        /// </summary>
        [DataMember]
        public string UPN { get; set; }

        /// <summary>
        /// Gets or sets the Login Name
        /// </summary>
        [DataMember]
        public string LoginName { get; set; }
    }
}
