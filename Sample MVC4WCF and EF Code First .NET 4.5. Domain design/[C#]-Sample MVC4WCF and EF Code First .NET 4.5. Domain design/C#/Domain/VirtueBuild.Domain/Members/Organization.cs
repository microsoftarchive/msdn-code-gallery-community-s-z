#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Organization.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members {
    #region

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Base;

    using Lookups;

    #endregion

    [DataContract]
    public class Organization : BaseEntity {

        public Organization()
        {
            Users = new List<User>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int OrgTypeId { get; set; }
        [DataMember]
        public virtual OrganizationType OrganizationType { get; set; }

        public ICollection<User> Users { get; set; }

    }
}