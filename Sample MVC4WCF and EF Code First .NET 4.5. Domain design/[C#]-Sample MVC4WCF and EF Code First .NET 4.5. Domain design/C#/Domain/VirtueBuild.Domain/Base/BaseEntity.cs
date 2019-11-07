#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  BaseEntity.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Base {
    #region

    using System;
    using System.Runtime.Serialization;

    #endregion

    [DataContract]
    public abstract class BaseEntity {

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public Guid? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedOn { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte SortOrder { get; set; }

    }
}