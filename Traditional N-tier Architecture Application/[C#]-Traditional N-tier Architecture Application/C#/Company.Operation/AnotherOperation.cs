// -----------------------------------------------------------------------
// <copyright file="AnotherOperation.cs" company="">
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
    public class AnotherOperation
        :IOperation<Another>
    {
        public IList<Another> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Another ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Another type)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Another type)
        {
            throw new NotImplementedException();
        }
    }
}
