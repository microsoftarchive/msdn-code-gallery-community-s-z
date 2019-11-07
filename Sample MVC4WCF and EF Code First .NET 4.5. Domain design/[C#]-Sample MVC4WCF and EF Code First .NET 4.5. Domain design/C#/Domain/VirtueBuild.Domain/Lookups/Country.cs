#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Country.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System;
    using System.Collections.Generic;

    using Files;

    using Members.Contacts;

    #endregion

    public class Country : IVisualImage {

        public Country()
        {
            Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public ICollection<Address> Addresses { get; set; }

        #region Implementation of ILookupWithImage

        public Guid? ImageGuid { get; set; }
        public Image Image { get; set; }

        #endregion
    }
}