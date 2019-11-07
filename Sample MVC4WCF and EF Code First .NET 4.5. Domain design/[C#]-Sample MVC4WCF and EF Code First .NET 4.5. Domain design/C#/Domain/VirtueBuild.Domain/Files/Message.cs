#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Message.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Files {
    #region

    using System;
    using System.Collections.Generic;

    using Base;

    #endregion

    public class Message : BaseEntity {

        public Message()
        {
            Attachments = new List<Attachment>();
        }

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public DateTime? SentOn { get; set; }
        public int RetryCount { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

    }
}