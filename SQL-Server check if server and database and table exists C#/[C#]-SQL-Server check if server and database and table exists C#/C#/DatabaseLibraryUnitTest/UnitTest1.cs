using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary;
using System.Threading.Tasks;

namespace DatabaseLibraryUnitTest
{
    /// <summary>
    /// Test methods in DataLibrary class project.
    /// </summary>
    /// <remarks>
    /// * Replace KARENS-PC with the name of your SQL-Server name
    /// * Several test assume specific objects (database and/or table) exists.
    ///   Why? because we are not testing if server or database exists in those
    ///   test but we do have test method above to test that.
    /// </remarks>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Determine if there are any SQL-Server's available
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task IsSqlServerAvailable()
        {
            Database ops = new Database();
            var result = await ops.SqlServerIsAvailable();
            Assert.IsTrue(result);

        }
        /// <summary>
        /// Determine if a specific SQL-Server is available
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task IsSqlServerAvailable_ByServerName()
        {
            var serverName = "KARENS-PC";
            Database ops = new Database();
            var result = await ops.SqlServerIsAvailable(serverName);
            Assert.IsTrue(result);

            serverName = "DOES_NOT_EXISTS";
            result = await ops.SqlServerIsAvailable(serverName);
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Determine if a database exists in a specific SQL-Server
        /// Assumes the server is available
        /// </summary>
        [TestMethod]
        public void DatabaseExists()
        {
            Database ops = new Database();
            var result = ops.DatabaseExists("KARENS-PC", "NorthWindAzure");
            Assert.IsTrue(result);

            result = ops.DatabaseExists("KARENS-PC", "NorthWind_Invalid");
            Assert.IsFalse(result);
        }
        /// <summary>
        /// Determine if a table exists in a database on a specfic SQL-Server.
        /// Assumes you provided a valid server and database
        /// </summary>
        [TestMethod]
        public void TableExistsInSpecificServerDatabase()
        {
            Database ops = new Database();
            var result = ops.TableExists("KARENS-PC", "CustomerDatabase", "Customer");
            Assert.IsTrue(result);

            result = ops.TableExists("KARENS-PC", "CustomerDatabase", "remotsuC");
            Assert.IsFalse(result);
        }
        /// <summary>
        /// This test assumes you provided a valid server and database 
        /// </summary>
        [TestMethod]
        public void GetTableNames()
        {
            Database ops = new Database();
            var tableNames = ops.TableNames("KARENS-PC", "CustomerDatabase");
            Assert.IsTrue(tableNames.Count > 0);
        }
    }
}
