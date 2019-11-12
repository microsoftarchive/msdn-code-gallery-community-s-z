#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  ContactType.cs
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

    public class ContactType {

        public ContactType()
        {
            Contacts = new List<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public ICollection<Contact> Contacts { get; set; }

    }
}