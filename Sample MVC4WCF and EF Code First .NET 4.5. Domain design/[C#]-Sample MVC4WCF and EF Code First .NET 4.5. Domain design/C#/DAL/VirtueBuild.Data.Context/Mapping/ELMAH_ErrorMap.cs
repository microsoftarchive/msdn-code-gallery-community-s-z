#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ELMAH_ErrorMap.cs
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

    using Domain.Lookups;

    #endregion

    public class ELMAH_ErrorMap : EntityTypeConfiguration<ELMAH_Error> {

        public ELMAH_ErrorMap()
        {
            // Primary Key
            HasKey(t => t.ErrorId);

            // Properties
            Property(t => t.Application).IsRequired().HasMaxLength(60);

            Property(t => t.Host).IsRequired().HasMaxLength(50);

            Property(t => t.Type).IsRequired().HasMaxLength(100);

            Property(t => t.Source).IsRequired().HasMaxLength(60);

            Property(t => t.Message).IsRequired().HasMaxLength(500);

            Property(t => t.User).IsRequired().HasMaxLength(50);

            Property(t => t.Sequence).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.AllXml).IsRequired();

            // Table & Column Mappings
            ToTable("ELMAH_Error");
            Property(t => t.ErrorId).HasColumnName("ErrorId");
            Property(t => t.Application).HasColumnName("Application");
            Property(t => t.Host).HasColumnName("Host");
            Property(t => t.Type).HasColumnName("Type");
            Property(t => t.Source).HasColumnName("Source");
            Property(t => t.Message).HasColumnName("Message");
            Property(t => t.User).HasColumnName("User");
            Property(t => t.StatusCode).HasColumnName("StatusCode");
            Property(t => t.TimeUtc).HasColumnName("TimeUtc");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.AllXml).HasColumnName("AllXml");
        }

    }
}