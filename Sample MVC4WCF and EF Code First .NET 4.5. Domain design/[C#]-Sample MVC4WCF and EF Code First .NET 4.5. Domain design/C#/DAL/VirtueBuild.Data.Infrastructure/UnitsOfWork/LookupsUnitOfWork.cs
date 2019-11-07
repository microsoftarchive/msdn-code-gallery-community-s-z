#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  LookupsUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Data.Infrastructure.UnitsOfWork {
    #region

    using Context.Sources;

    using Interfaces.Repository.Lookups;
    using Interfaces.Uow.Lookups;

    using Repositories.Lookups;

    #endregion

    public class LookupsUnitOfWork : BaseCoreUnitOfWork, ILookupsUnitOfWork {

        private readonly ILookupsRespository _lookupsRespository;

        public LookupsUnitOfWork(OpenFrameworkCoreContext context)
            : base(context)
        {
            _lookupsRespository = new LookupsRespository(context);
        }

        public LookupsUnitOfWork()
            : base(new OpenFrameworkCoreContext())
        {
            _lookupsRespository = new LookupsRespository(Context);
        }

        #region ILookupsUnitOfWork Members

        public ILookupsRespository LookupsRespository { get { return _lookupsRespository; } }

        #endregion
    }
}