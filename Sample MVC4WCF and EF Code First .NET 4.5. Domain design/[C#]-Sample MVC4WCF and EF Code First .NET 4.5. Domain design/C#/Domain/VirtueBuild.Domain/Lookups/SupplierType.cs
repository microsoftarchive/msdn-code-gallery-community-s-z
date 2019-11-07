#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  SupplierType.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System.Collections.Generic;

    using Vendor;

    #endregion

    public class SupplierType {

        public SupplierType()
        {
            Suppliers = new List<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }

    }
}