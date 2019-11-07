// -----------------------------------------------------------------------
// <copyright file="OtherOperation.cs" company="">
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
    public class OtherOperation
        :IOperation<Other>
    {
        public IList<Other> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Other ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Other type)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Other type)
        {
            throw new NotImplementedException();
        }
    }
}
