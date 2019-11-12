#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  RepositoryBase.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.Repositories {
    #region

    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Context.Sources;

    using Interfaces.Repository;

    #endregion

    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class {

        protected RepositoryBase(DbContext context)
        {
            Set = context.Set<T>();
            Context = context as OpenFrameworkCoreContext;
        }

        protected OpenFrameworkCoreContext Context { get; private set; }

        protected DbSet<T> Set { get; set; }

        #region IRepository<T> Members

        public virtual void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public virtual void Insert(T entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(T entity)
        {
            Set.Attach(entity);
        }

        #endregion
    }
}