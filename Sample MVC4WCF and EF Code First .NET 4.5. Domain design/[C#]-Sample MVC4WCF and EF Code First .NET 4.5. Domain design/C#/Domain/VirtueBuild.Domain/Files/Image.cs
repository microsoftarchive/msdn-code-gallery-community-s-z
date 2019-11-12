#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Image.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Files {
    #region

    using System;

    using Base;

    #endregion

    public class Image : BaseEntity {

        public Guid ImageGuid { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Context { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Size { get; set; }
        public string Resolution { get; set; }
        public string Description { get; set; }
        public int? DisplayPositionX { get; set; }
        public int? DisplayPositionY { get; set; }

    }
}