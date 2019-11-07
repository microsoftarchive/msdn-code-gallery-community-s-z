#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ContactUMap.cs
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

    public class ContactUMap : EntityTypeConfiguration<ContactUs> {

        public ContactUMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.FirstName).HasMaxLength(100);

            Property(t => t.LastName).HasMaxLength(100);

            Property(t => t.Email).HasMaxLength(382);

            Property(t => t.Phone).HasMaxLength(20);

            Property(t => t.Comments).HasMaxLength(1000);

            Property(t => t.Notes).HasMaxLength(500);

            // Table & Column Mappings
            ToTable("ContactUs");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Phone).HasColumnName("Phone");
            Property(t => t.Comments).HasColumnName("Comments");
            Property(t => t.SubmittedDate).HasColumnName("SubmittedDate");
            Property(t => t.ContactStatusId).HasColumnName("ContactStatusId");
            Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            HasOptional(t => t.ContactStatu).WithMany(t => t.ContactUs).HasForeignKey(d => d.ContactStatusId);
        }

    }
}