#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Attachment.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Files {
    #region

    using Base;

    #endregion

    public class Attachment : BaseEntity {

        public int Id { get; set; }
        public int MessageId { get; set; }
        public string FileName { get; set; }
        public byte[] Context { get; set; }

        public virtual Message Message { get; set; }

    }
}