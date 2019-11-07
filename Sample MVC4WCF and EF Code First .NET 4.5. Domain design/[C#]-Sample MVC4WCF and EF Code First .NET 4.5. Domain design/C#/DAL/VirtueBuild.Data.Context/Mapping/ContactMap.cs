#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ContactMap.cs
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

    using Domain.Members.Contacts;

    #endregion

    public class ContactMap : EntityTypeConfiguration<Contact> {

        public ContactMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.FirstName).HasMaxLength(100);

            Property(t => t.LastName).HasMaxLength(100);

            Property(t => t.MiddleName).HasMaxLength(50);

            Property(t => t.CustomerNumber).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Contact");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.MiddleName).HasColumnName("MiddleName");
            Property(t => t.CustomerNumber).HasColumnName("CustomerNumber");
            Property(t => t.ContactTypeId).HasColumnName("ContactTypeId");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");

            // Relationships
            HasRequired(t => t.ContactType).WithMany(t => t.Contacts).HasForeignKey(d => d.ContactTypeId);
        }

    }
}