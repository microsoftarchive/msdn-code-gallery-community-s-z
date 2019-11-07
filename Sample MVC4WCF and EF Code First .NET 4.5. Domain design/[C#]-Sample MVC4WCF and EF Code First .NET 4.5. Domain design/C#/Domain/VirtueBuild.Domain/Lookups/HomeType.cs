#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  HomeType.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Files;

    #endregion

    public class HomeType : IVisualImage {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Order")]
        public byte SortOrder { get; set; }

        #region IVisualImage Members

        public Guid? ImageGuid { get; set; }

        public virtual Image Image { get; set; }

        #endregion
    }
}