#region File Attributes

// AdminWeb  Project: VirtueBuild.Security
// File:  ISecuritySettings.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Security {
    #region

    using System.Collections.Generic;

    #endregion

    public interface ISecuritySettings {

        /// <summary>
        ///     Gets or sets an encryption key
        /// </summary>
        string EncryptionKey { get; set; }

        /// <summary>
        ///     Gets or sets a list of adminn area allowed IP addresses
        /// </summary>
        List<string> AdminAreaAllowedIpAddresses { get; set; }

        /// <summary>
        ///     Gets or sets a vaule indicating whether to hide admin menu items based on ACL
        /// </summary>
        bool HideAdminMenuItemsBasedOnPermissions { get; set; }

    }
}