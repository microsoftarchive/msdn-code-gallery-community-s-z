#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  UnitOfMeasureMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Lookups;

    #endregion

    public class UnitOfMeasureMap : EntityTypeConfiguration<UnitOfMeasure> {

        public UnitOfMeasureMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            ToTable("UnitOfMeasure", "Lookup");
        }

    }
}