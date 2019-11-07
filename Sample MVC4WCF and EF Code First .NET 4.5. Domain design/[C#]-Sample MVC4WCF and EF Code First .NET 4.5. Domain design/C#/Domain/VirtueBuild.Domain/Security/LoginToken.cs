#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  LoginToken.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Security {
    #region

    using System;

    using Base;

    #endregion

    public class LoginToken : BaseEntity {
        #region Properties

        //public virtual int LoginTokenId { get; set; }

        public virtual Guid TokenKey { get; set; }

        public virtual DateTime TokenExpiration { get; set; }

        public virtual string UserName { get; set; }

        public bool IsValid { get { return TokenExpiration > DateTime.Now; } }

        #endregion
    }
}