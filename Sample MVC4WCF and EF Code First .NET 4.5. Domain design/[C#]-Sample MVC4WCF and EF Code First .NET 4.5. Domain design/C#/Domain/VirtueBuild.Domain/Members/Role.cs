#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Role.cs
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

    #endregion

    [DataContract]
    public class Role {

        public Role()
        {
            Users = new List<User>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool SystemRole { get; set; }

        [DataMember]
        public int? OrgId { get; set; }

        public ICollection<User> Users { get; set; }

    }
}