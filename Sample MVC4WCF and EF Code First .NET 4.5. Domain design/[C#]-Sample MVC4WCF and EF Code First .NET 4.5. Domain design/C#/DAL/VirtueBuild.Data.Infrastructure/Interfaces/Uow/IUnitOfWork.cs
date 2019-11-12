#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  IUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Data.Infrastructure.Interfaces.Uow {
    #region

    using System;
    using System.Data.Entity;

    #endregion

    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : DbContext {

        TContext Context { get; }

        void Save();

    }
}