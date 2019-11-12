#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  ILookupsUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Data.Infrastructure.Interfaces.Uow.Lookups {
    #region

    using Context.Sources;

    using Repository.Lookups;

    #endregion

    public interface ILookupsUnitOfWork : IUnitOfWork<OpenFrameworkCoreContext> {

        ILookupsRespository LookupsRespository { get; }

    }
}