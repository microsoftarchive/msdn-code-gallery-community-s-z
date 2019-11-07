#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  RoleMap.cs
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

    public class RoleMap : EntityTypeConfiguration<Role> {

        public RoleMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Role");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.SystemRole).HasColumnName("SystemRole");

            // Relationships
            HasMany(t => t.Users).WithMany(t => t.Roles).Map(
                m => {
                    m.ToTable("UserInRole");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserGuid");
                });
        }

    }
}