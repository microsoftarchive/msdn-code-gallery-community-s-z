#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  OrganizationType.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System.Collections.Generic;

    using Members;

    #endregion

    public class OrganizationType {

        public OrganizationType()
        {
            Organizations = new List<Organization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }

        public ICollection<Organization> Organizations { get; set; }

    }
}