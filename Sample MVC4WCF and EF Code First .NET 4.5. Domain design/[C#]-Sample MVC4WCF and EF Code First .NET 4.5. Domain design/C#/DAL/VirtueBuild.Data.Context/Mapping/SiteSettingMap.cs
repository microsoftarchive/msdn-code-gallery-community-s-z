#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  SiteSettingMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Settings;

    #endregion

    public class SiteSettingMap : EntityTypeConfiguration<SiteSetting> {

        public SiteSettingMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Setting).IsRequired().HasMaxLength(200);

            Property(t => t.Description).IsRequired().HasMaxLength(500);

            Property(t => t.Value).IsRequired().HasMaxLength(2000);

            // Table & Column Mappings
            ToTable("SiteSetting");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Setting).HasColumnName("Setting");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Value).HasColumnName("Value");
            Property(t => t.IsRequired).HasColumnName("IsRequired");
            Property(t => t.IsCustom).HasColumnName("IsCustom");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");
        }

    }
}