#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  MessageMap.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Mapping {
    #region

    using System.Data.Entity.ModelConfiguration;

    using Domain.Files;

    #endregion

    public class MessageMap : EntityTypeConfiguration<Message> {

        public MessageMap()
        {
            HasKey(t => t.Id);

            ToTable("Message");
        }

    }
}