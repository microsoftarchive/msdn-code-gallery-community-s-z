#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Supplier.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Vendor {
    #region

    using System;

    using Lookups;

    #endregion

    public class Supplier {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public int? SupplierTypeId { get; set; }
        public virtual SupplierType SupplierType { get; set; }

    }
}