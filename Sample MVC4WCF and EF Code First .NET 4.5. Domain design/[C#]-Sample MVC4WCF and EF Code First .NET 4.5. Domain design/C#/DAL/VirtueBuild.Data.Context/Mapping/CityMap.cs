#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  CityMap.cs
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

    public class CityMap : EntityTypeConfiguration<City> {

        public CityMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("City", "Lookup");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.StateId).HasColumnName("StateId");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.GeoLat).HasColumnName("GeoLat");
            Property(t => t.GeoLong).HasColumnName("GeoLong");
            Property(t => t.ImageGuid).HasColumnName("ImageGuid");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");
        }

    }
}