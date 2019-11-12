#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  UserContactMap.cs
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

    public class UserContactMap : EntityTypeConfiguration<UserContact> {

        public UserContactMap()
        {
            // Primary Key
            HasKey(t => new {t.UserGuid, t.ContactId});

            // Properties
            Property(t => t.ContactId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("UserContact");
            Property(t => t.UserGuid).HasColumnName("UserGuid");
            Property(t => t.ContactId).HasColumnName("ContactId");

            // Relationships
            HasRequired(t => t.Contact).WithMany(t => t.ContactUsers).HasForeignKey(d => d.ContactId);
        }

    }
}