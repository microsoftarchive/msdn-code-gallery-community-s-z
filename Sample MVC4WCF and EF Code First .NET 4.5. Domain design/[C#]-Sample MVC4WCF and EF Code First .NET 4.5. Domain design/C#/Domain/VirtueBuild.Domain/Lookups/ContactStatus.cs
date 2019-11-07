#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  ContactStatus.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System.Collections.Generic;

    using Members.Contacts;

    #endregion

    public sealed class ContactStatus {

        public ContactStatus()
        {
            ContactUs = new List<ContactUs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public ICollection<ContactUs> ContactUs { get; set; }

    }
}