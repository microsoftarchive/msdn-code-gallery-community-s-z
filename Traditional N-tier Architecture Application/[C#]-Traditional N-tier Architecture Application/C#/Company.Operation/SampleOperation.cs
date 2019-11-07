// -----------------------------------------------------------------------
// <copyright file="SampleOperation.cs" company="">
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
    public class SampleOperation
        :IOperation<Sample>
    {

        public IList<Sample> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Sample ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Sample type)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Sample type)
        {
            throw new NotImplementedException();
        }
    }
}
