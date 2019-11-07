#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  Application.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Settings {
    #region

    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Members;

    #endregion

    [DataContract]
    public class Application {

        public Application()
        {
            Users = new List<User>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }

    }
}