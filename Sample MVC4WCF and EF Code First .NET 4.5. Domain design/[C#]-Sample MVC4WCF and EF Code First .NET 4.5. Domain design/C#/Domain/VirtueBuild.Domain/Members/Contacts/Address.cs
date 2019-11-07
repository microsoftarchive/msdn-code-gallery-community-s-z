#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Address.cs
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
    public class Address : BaseEntity {

        public Address()
        {
            Contacts = new List<Contact>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public int? CityId { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public int? StateId { get; set; }

        [DataMember]
        public int? CountryId { get; set; }

        [DataMember]
        public int AddressTypeId { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}