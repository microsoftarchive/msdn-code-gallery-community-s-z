#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  VendorType.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System;

    using Files;

    #endregion

    public class VendorType : IVisualImage {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }

        #region Implementation of ILookupWithImage

        public Guid? ImageGuid { get; set; }
        public Image Image { get; set; }

        #endregion
    }
}