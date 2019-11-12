#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ApplicationMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Domain.Settings;

    #endregion

    public class ApplicationMap : EntityTypeConfiguration<Application> {

        public ApplicationMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Application");
            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Name).HasColumnName("Name");
        }

    }
}