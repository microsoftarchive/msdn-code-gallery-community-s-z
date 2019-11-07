#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  PermissionRecord.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Security {
    #region

    using System.Collections.Generic;

    using Base;

    using Members;

    #endregion

    /// <summary>
    ///     Represents a permission record
    /// </summary>
    public class PermissionRecord : BaseEntity {

        private ICollection<Role> _roles;

        /// <summary>
        ///     Gets or sets the permission name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Gets or sets the permission system name
        /// </summary>
        public virtual string SystemName { get; set; }

        /// <summary>
        ///     Gets or sets the permission category
        /// </summary>
        public virtual string Category { get; set; }

        /// <summary>
        ///     Gets or sets discount usage history
        /// </summary>
        public virtual ICollection<Role> Roles { get { return _roles ?? (_roles = new List<Role>()); } protected set { _roles = value; } }

    }
}