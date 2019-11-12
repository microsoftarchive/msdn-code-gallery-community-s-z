#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  LoginResult.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Security {
    #region

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    #endregion

    // Add by GovX
    [DataContract]
    public class LoginResult {

        [DataMember]
        public bool IsValidUser { get; set; }

        [DataMember]
        public bool IsLockedOut { get; set; }

        [DataMember]
        public int LoginFailureCount { get; set; }

        [DataMember]
        public string LoginToken { get; set; }

        [DataMember]
        public DateTime TokenExpiration { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public List<Verification> Verifications { get; set; }

    }

    [DataContract]
    public class Verification {

        [DataMember]
        public string TypeName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Approved { get; set; }

        [DataMember]
        public DateTime ApprovalDate { get; set; }

        [DataMember]
        public string ApprovalMethod { get; set; }

    }
}