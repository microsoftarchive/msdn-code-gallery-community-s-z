#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ImageMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Files;

    #endregion

    public class ImageMap : EntityTypeConfiguration<Image> {

        public ImageMap()
        {
            // Primary Key
            HasKey(t => t.ImageGuid);

            // Properties
            Property(t => t.Name).IsRequired().HasMaxLength(255);

            Property(t => t.Extension).HasMaxLength(10);

            // Table & Column Mappings
            ToTable("Image");
            Property(t => t.ImageGuid).HasColumnName("ImageGuid");
        }

    }
}