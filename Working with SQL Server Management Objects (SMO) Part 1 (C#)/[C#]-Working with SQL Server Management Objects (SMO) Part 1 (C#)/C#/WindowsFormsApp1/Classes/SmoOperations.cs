using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Various methods to demo working with smo objects.
    /// </summary>
    /// <remarks>
    /// References needed are under the following folder where may be different
    /// depending on the version of SQL-Server installed, most likely at the 
    /// 130 part.
    /// C:\Program Files\Microsoft SQL Server\130\SDK\Assemblies
    /// 
    /// </remarks>
    public class SmoOperations
    {
        /// <summary>
        /// Your server name e.g. could be (local) or perhaps .\SQLEXPRESS
        /// </summary>
        public string ServerName { get => "KARENS-PC"; }
        private Server mServer;
        public SmoOperations()
        {
            mServer = InitializeServer();
        }
        Server InitializeServer()
        {
            ServerConnection connection = new ServerConnection(ServerName);
            Server sqlServer = new Server(connection);
            return sqlServer;
        }

        public List<string> DatabaseNames()
        {
            var databaseNames = new List<string>();
            var server = mServer;
            return server.Databases.OfType<Database>().Select(db => db.Name).ToList();
        }
        /// <summary>
        /// Determine if database exists on the server.
        /// </summary>
        /// <param name="pDatabaseName"></param>
        /// <returns></returns>
        public bool DatabaseExists(string pDatabaseName)
        {
            var databaseNames = new List<string>();
            var server = mServer;
            var item = server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Return a valid Database based on a database name
        /// </summary>
        /// <param name="pDatabaseName"></param>
        /// <returns></returns>
        public Database GetDatabase(string pDatabaseName)
        {
            var databaseNames = new List<string>();
            var server = mServer;
            return server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);
        }
        /// <summary>
        /// Get table names for database
        /// </summary>
        /// <param name="pDatabaseName">Exists SQL-Server database</param>
        /// <returns></returns>
        /// <remarks>System objects/tables are filtered out</remarks>
        public List<string> TableNames(string pDatabaseName)
        {
            var tableNames = new List<string>(); 
            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(tbl => tbl.Name == pDatabaseName);

            if (database != null)
            {
                tableNames = database.Tables.OfType<Table>().Where(tbl => !tbl.IsSystemObject).Select(tbl => tbl.Name).ToList();
            }

            return tableNames;

        }
        /// <summary>
        /// Does the table exists in the specified database
        /// </summary>
        /// <param name="pDatabaseName">valid SQL-Server database</param>
        /// <param name="pTableName">Table name to see if it exists in pDatabaseName</param>
        /// <returns></returns>
        public bool TableExists(string pDatabaseName, string pTableName)
        {
            bool exists = false;
            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(tbl => tbl.Name == pDatabaseName);

            if (database != null)
            {
                exists = (database.Tables.OfType<Table>().Where(tbl => !tbl.IsSystemObject).FirstOrDefault(tbl => tbl.Name == pTableName) != null);
            }

            return exists;
        }
        /// <summary>
        /// Get column names for table in database.
        /// </summary>
        /// <param name="pDatabaseName">valid SQL-Server database</param>
        /// <param name="pTableName">Exists table in pDatabaseName</param>
        /// <returns></returns>
        public List<string> TableColumnNames(string pDatabaseName, string pTableName)
        {
            var columnNames = new List<string>();
            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);

            if (database != null)
            {
                var table = database.Tables.OfType<Table>().FirstOrDefault(tbl => tbl.Name == pTableName);

                if (table != null)
                {
                    
                    columnNames = table.Columns.OfType<Column>().Select(col => col.Name).ToList();
                }
            }

            return columnNames;
        }
        /// <summary>
        /// Does a column name exists in a table within a specific database
        /// </summary>
        /// <param name="pDatabaseName">valid SQL-Server database</param>
        /// <param name="pTableName">Exists table in pDatabaseName</param>
        /// <param name="pColumnName">Column to check if it exists in pTableName in pDatabaseName</param>
        /// <returns></returns>
        public bool ColumnExists(string pDatabaseName, string pTableName, string pColumnName)
        {
            bool exists = false;

            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);

            if (database != null)
            {
                var table = database.Tables.OfType<Table>().FirstOrDefault(tbl => tbl.Name == pTableName);
                if (table != null)
                {
                    exists = (table.Columns.OfType<Column>().FirstOrDefault(col => col.Name == pColumnName) != null);
                }
            }

            return exists;
        }
        /// <summary>
        /// Get details for each column in a table within a database.
        /// There are more details then returned here so feel free to explore.
        /// </summary>
        /// <param name="pDatabaseName">valid SQL-Server database</param>
        /// <param name="pTableName">Exists table in pDatabaseName</param>
        /// <returns></returns>
        public List<ColumnDetails> GetColumnDetails(string pDatabaseName, string pTableName)
        {
            var columnDetails = new List<ColumnDetails>();
            var columnNames = new List<string>();
            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);

            if (database != null)
            {
                var table = database.Tables.OfType<Table>().FirstOrDefault(tbl => tbl.Name == pTableName);

                if (table != null)
                {
                    columnDetails = table.Columns.OfType<Column>().Select(col => new ColumnDetails()
                    {
                        Identity = col.Identity,
                        DataType = col.DataType,
                        Name = col.Name,
                        InPrimaryKey = col.InPrimaryKey,
                        Nullable = col.Nullable
                    }).ToList();
                }
            }

            return columnDetails;
        }
        /// <summary>
        /// Get foreign key details for specified table in specified database
        /// </summary>
        /// <param name="pDatabaseName">valid SQL-Server database</param>
        /// <param name="pTableName">Exists table in pDatabaseName</param>
        /// <returns></returns>
        public List<ForeignKeysDetails> TableKeys(string pDatabaseName, string pTableName)
        {
            var keyList = new List<ForeignKeysDetails>();
            var server = mServer;
            var database = server.Databases.OfType<Database>().FirstOrDefault(db => db.Name == pDatabaseName);
            if (database != null)
            {
                var table = database.Tables.OfType<Table>().FirstOrDefault(tbl => tbl.Name == pTableName);
                if (table != null)
                {
                    foreach (Column item in table.Columns.OfType<Column>())
                    {
                        List< ForeignKeysDetails> fkds = item.EnumForeignKeys().AsEnumerable().Select(row => new ForeignKeysDetails
                        {
                            TableSchema = row.Field<string>("Table_Schema"),
                            TableName = row.Field<string>("Table_Name"),
                            SchemaName = row.Field<string>("Name")
                        }).ToList();

                        foreach (ForeignKeysDetails ts in fkds)
                        {
                            keyList.Add(ts);
                        }
                    }
                }
            }

            return keyList;

        }
    }


}
