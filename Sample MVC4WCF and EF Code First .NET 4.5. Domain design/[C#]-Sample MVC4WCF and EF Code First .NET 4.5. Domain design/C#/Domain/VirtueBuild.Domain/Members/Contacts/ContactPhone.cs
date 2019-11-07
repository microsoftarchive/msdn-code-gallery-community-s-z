#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  ContactPhone.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members.Contacts {
    #region

    using System.Runtime.Serialization;

    using Base;

    using Lookups;

    #endregion

    [DataContract]
    public class ContactPhone : BaseEntity {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int PhoneTypeId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual PhoneType PhoneType { get; set; }

    }
}