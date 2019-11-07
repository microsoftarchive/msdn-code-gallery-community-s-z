#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  City.cs
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

    using Base;

    using Members.Contacts;

    #endregion

    public class City : BaseEntity {

        public City()
        {
            Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public decimal? GeoLat { get; set; }
        public decimal? GeoLong { get; set; }
        public Guid? ImageGuid { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}