#region File Attributes

// AdminWeb  Project: VirtueBuild.Security
// File:  SecuritySettings.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Security {
    #region

    using System.Collections.Generic;

    #endregion

    public class SecuritySettings : ISecuritySettings {
        #region Implementation of ISecuritySettings

        public string EncryptionKey { get; set; }
        public List<string> AdminAreaAllowedIpAddresses { get; set; }
        public bool HideAdminMenuItemsBasedOnPermissions { get; set; }

        #endregion
    }
}