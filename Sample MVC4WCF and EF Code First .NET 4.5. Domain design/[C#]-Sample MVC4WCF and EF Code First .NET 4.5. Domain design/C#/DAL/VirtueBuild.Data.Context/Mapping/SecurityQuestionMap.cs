#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  SecurityQuestionMap.cs
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

    public class SecurityQuestionMap : EntityTypeConfiguration<SecurityQuestion> {

        public SecurityQuestionMap()
        {
            // Primary Key
            HasKey(t => t.SecurityQuestionId);

            // Properties
            Property(t => t.Question).IsRequired().HasMaxLength(50);

            Property(t => t.Answer).HasMaxLength(200);

            // Table & Column Mappings
            ToTable("SecurityQuestion");
            Property(t => t.SecurityQuestionId).HasColumnName("SecurityQuestionId");
            Property(t => t.Question).HasColumnName("Question");
            Property(t => t.Active).HasColumnName("Active");
            Property(t => t.Answer).HasColumnName("Answer");
            Property(t => t.UserGuid).HasColumnName("UserGuid");

            // Relationships
            HasRequired(t => t.User).WithMany(t => t.SecurityQuestions).HasForeignKey(d => d.UserGuid);
        }

    }
}