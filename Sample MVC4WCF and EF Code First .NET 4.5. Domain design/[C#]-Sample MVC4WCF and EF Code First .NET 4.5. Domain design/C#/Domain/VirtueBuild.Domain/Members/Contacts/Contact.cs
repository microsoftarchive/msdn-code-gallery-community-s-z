#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Contact.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members.Contacts {
    #region

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Base;

    using Lookups;

    #endregion

    [DataContract]
    public class Contact : BaseEntity {

        public Contact()
        {
            ContactPhones = new List<ContactPhone>();
            ContactUsers = new List<UserContact>();
            Addresses = new List<Address>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string CustomerNumber { get; set; }

        [DataMember]
        public int ContactTypeId { get; set; }

        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<ContactPhone> ContactPhones { get; set; }
        public virtual ICollection<UserContact> ContactUsers { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}