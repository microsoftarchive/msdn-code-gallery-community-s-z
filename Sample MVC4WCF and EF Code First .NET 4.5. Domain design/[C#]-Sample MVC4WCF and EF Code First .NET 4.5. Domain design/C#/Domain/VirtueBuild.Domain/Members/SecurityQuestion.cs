#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  SecurityQuestion.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members {
    #region

    using System;
    using System.Runtime.Serialization;

    #endregion

    [DataContract]
    public class SecurityQuestion {
        [DataMember]
        public int SecurityQuestionId { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string Answer { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
                
        public virtual User User { get; set; }

    }
}