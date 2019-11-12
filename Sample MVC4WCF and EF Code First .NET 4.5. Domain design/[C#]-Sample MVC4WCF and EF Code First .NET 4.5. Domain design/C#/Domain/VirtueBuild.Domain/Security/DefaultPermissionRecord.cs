#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  DefaultPermissionRecord.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Security {
    #region

    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Represents a default permission record
    /// </summary>
    public class DefaultPermissionRecord {

        public DefaultPermissionRecord()
        {
            PermissionRecords = new List<PermissionRecord>();
        }

        /// <summary>
        ///     Gets or sets the customer role system name
        /// </summary>
        public string CustomerRoleSystemName { get; set; }

        /// <summary>
        ///     Gets or sets the permissions
        /// </summary>
        public IEnumerable<PermissionRecord> PermissionRecords { get; set; }

    }
}