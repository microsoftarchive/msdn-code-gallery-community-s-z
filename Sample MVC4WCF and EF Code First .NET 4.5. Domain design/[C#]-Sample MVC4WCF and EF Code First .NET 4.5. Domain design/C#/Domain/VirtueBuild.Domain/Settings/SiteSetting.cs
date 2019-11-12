#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  SiteSetting.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Settings {
    #region

    using Base;

    #endregion

    public class SiteSetting : BaseEntity {

        public int Id { get; set; }
        public string Setting { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public bool IsCustom { get; set; }

    }
}