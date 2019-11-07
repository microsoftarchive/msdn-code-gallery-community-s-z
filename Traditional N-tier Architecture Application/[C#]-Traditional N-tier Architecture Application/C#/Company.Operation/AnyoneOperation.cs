// -----------------------------------------------------------------------
// <copyright file="AnyoneOperation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Operation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Company.Entity;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AnyoneOperation
        :IOperation<Anyone>
    {
        public IList<Anyone> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Anyone ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Anyone type)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Anyone type)
        {
            throw new NotImplementedException();
        }
    }
}
