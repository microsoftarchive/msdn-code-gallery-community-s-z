using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MasaSam.Data
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Execute stored procedure with single table value parameter.
        /// </summary>
        /// <typeparam name="T">Type of object to store.</typeparam>
        /// <param name="context">DbContext instance.</param>
        /// <param name="data">Data to store</param>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="paramName">Parameter name</param>
        /// <param name="typeName">User table type name</param>
        public static void ExecuteTableValueProcedure<T>(this DbContext context, IEnumerable<T> data, string procedureName, string paramName, string typeName)
        {
            //// convert source data to DataTable
            DataTable table = data.ToDataTable();

            //// create parameter
            SqlParameter parameter = new SqlParameter(paramName, table);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = typeName;

            //// execute sp sql
            string sql = String.Format("EXEC {0} {1};", procedureName, paramName);

            //// execute sql
            context.Database.ExecuteSqlCommand(sql, parameter);
        }
    }
}
