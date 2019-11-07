#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  LanguageMap.cs
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

    public class LanguageMap : EntityTypeConfiguration<Language> {

        public LanguageMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(100);

            Property(t => t.Culture).IsRequired().HasMaxLength(100);

            Property(t => t.CultureName).HasMaxLength(20);

            // Table & Column Mappings
            ToTable("Languages", "Lookup");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Culture).HasColumnName("Culture");
            Property(t => t.CultureName).HasColumnName("CultureName");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");
        }

    }
}