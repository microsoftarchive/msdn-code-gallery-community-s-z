// -----------------------------------------------------------------------
// <copyright file="IOperation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Operation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    interface IOperation<T>
    {
        IList<T> ReadAll();
        T ReadById(int Id);
        int Insert(T type);
        int Delete(int id);
        int Update(T type);
    }
}
