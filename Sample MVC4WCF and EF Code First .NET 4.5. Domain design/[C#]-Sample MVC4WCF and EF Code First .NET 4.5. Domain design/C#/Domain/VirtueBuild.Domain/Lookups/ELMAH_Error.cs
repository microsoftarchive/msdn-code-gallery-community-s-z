#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  ELMAH_Error.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System;

    #endregion

    public class ELMAH_Error {

        public Guid ErrorId { get; set; }
        public string Application { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeUtc { get; set; }
        public int Sequence { get; set; }
        public string AllXml { get; set; }

    }
}