#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  OrganizationMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Members;

    #endregion

    public class OrganizationMap : EntityTypeConfiguration<Organization> {

        public OrganizationMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(250);

            Property(t => t.Description).HasMaxLength(500);

            // Table & Column Mappings
            ToTable("Organization");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.OrgTypeId).HasColumnName("OrgTypeId");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");

            // Relationships
            HasRequired(t => t.OrganizationType).WithMany(t => t.Organizations).HasForeignKey(d => d.OrgTypeId);
        }

    }
}