#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  IVisualImage.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System;

    using Files;

    #endregion

    public interface IVisualImage {

        Guid? ImageGuid { get; set; }

        Image Image { get; set; }

    }
}