#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ContactPhoneMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Members.Contacts;

    #endregion

    public class ContactPhoneMap : EntityTypeConfiguration<ContactPhone> {

        public ContactPhoneMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Phone).IsRequired().HasMaxLength(100);

            // Table & Column Mappings
            ToTable("ContactPhone");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ContactId).HasColumnName("ContactId");
            Property(t => t.Phone).HasColumnName("Phone");
            Property(t => t.PhoneTypeId).HasColumnName("PhoneTypeId");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");

            // Relationships
            HasRequired(t => t.Contact).WithMany(t => t.ContactPhones).HasForeignKey(d => d.ContactId);
            HasRequired(t => t.PhoneType).WithMany(t => t.ContactPhones).HasForeignKey(d => d.PhoneTypeId);
        }

    }
}