#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  UserMap.cs
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

    public class UserMap : EntityTypeConfiguration<User> {

        public UserMap()
        {
            // Primary Key
            HasKey(t => t.UserGuid);

            // Properties
            Property(t => t.UserName).IsRequired().HasMaxLength(50);

            Property(t => t.Email).IsRequired().HasMaxLength(200);

            Property(t => t.Salt).IsRequired().HasMaxLength(250);

            Property(t => t.Password).IsRequired().HasMaxLength(250);

            Property(t => t.PasswordQuestion).HasMaxLength(50);

            Property(t => t.PasswordAnswer).HasMaxLength(255);

            // Table & Column Mappings
            ToTable("User");
            Property(t => t.UserGuid).HasColumnName("UserGuid").IsRequired();
            Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            Property(t => t.UserName).HasColumnName("UserName").IsRequired();
            Property(t => t.Email).HasColumnName("Email").IsRequired();
            Property(t => t.IsApproved).HasColumnName("IsApproved");
            Property(t => t.Salt).HasColumnName("Salt").IsRequired();
            Property(t => t.Password).HasColumnName("Password").IsRequired();
            Property(t => t.PasswordQuestion).HasColumnName("PasswordQuestion");
            Property(t => t.PasswordAnswer).HasColumnName("PasswordAnswer");
            Property(t => t.PasswordFormat).HasColumnName("PasswordFormat");
            Property(t => t.LastLogin).HasColumnName("LastLogin");
            Property(t => t.LastActivity).HasColumnName("LastActivity");
            Property(t => t.LastPasswordChange).HasColumnName("LastPasswordChange");
            Property(t => t.LastLockout).HasColumnName("LastLockout");
            Property(t => t.FailedPasswordAttempts).HasColumnName("FailedPasswordAttempts");
            Property(t => t.FailedAnswerAttempts).HasColumnName("FailedAnswerAttempts");
            Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            Property(t => t.IsLocked).HasColumnName("IsLocked");
            Property(t => t.Online).HasColumnName("Online");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.SortOrder).HasColumnName("SortOrder");

            // Relationships
            HasRequired(t => t.Application).WithMany(t => t.Users).HasForeignKey(d => d.ApplicationId);
            HasRequired(t => t.Organization).WithMany(t => t.Users).HasForeignKey(o => o.OrgId);
        }

    }
}