#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  BaseCoreUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.UnitsOfWork {
    #region

    using System;
    using System.Data.Entity.Validation;

    using Context.Sources;

    using Elmah;

    #endregion

    public abstract class BaseCoreUnitOfWork : IDisposable {

        private bool _disposed;

        protected BaseCoreUnitOfWork(OpenFrameworkCoreContext context)
        {
            Context = context;
        }

        public OpenFrameworkCoreContext Context { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void Dispose(bool disposing)
        {
            if (Context != null && !_disposed && disposing) {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Save()
        {
            try {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                ErrorLog errorLog = new SqlErrorLog(Context.Database.Connection.ConnectionString);
                errorLog.Log(new Error(ex));
                throw;
            }
        }

    }
}