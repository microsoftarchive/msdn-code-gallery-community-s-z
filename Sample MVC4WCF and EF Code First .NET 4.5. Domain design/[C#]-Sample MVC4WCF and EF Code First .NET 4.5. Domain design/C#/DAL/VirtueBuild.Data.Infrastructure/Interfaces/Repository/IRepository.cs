#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  IRepository.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.Interfaces.Repository {
    #region

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    public interface IRepository<T>
        where T : class {

        void Delete(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        void Insert(T entity);

        void Update(T entity);

    }
}