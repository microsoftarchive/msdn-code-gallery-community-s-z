#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  ContactUs.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members.Contacts {
    #region

    using System;
    using System.Runtime.Serialization;

    using Lookups;

    #endregion

    [DataContract]
    public class ContactUs {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OrgId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public DateTime SubmittedDate { get; set; }

        [DataMember]
        public int? ContactStatusId { get; set; }

        [DataMember]
        public string Notes { get; set; }

        public virtual ContactStatus ContactStatu { get; set; }
        public virtual Organization Organization { get; set; }

    }
}