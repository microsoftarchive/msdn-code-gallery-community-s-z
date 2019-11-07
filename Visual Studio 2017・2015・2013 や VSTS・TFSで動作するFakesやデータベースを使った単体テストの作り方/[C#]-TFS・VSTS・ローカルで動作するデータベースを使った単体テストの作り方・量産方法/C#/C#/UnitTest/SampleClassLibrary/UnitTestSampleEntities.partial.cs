using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary
{
    public partial class UnitTestSampleEntities
    {
        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection
        /// string for the database to which a connection will be made.  See the class
        /// remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="connectionString">
        /// Either the database name or a connection string.
        /// </param>
        public UnitTestSampleEntities(string connectionString)
            : base(connectionString)
        {
        } // end constructor

    } // end class
} // end namespace
