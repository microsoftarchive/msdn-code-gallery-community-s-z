#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  State.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Lookups {
    #region

    using System.Collections.Generic;

    using Members.Contacts;

    #endregion

    public class State {

        public State()
        {
            Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public bool IsActive { get; set; }
        public byte SortOrder { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}