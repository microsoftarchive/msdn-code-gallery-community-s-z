#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  UserContact.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members.Contacts {
    #region

    using System;

    #endregion

    public class UserContact {

        public Guid UserGuid { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

    }
}