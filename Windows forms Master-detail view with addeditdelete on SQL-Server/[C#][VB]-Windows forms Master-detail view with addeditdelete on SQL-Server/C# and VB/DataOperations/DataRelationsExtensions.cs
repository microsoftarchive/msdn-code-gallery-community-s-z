using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations
{
    public static class DataRelationsExtensions
    {
        /// <summary>
        /// USed to create a one to many relationship for a master-detail in a DataSet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="MasterTableName">master table</param>
        /// <param name="ChildTableName">child table of master table</param>
        /// <param name="MasterKeyColumn">master table primary key</param>
        /// <param name="ChildKeyColumn">child table of master's primary key</param>
        public static void SetRelation(this DataSet sender, string MasterTableName, string ChildTableName, string MasterKeyColumn, string ChildKeyColumn)
        {
            sender.Relations.Add(new DataRelation(string.Concat(MasterTableName, ChildTableName), sender.Tables[MasterTableName].Columns[MasterKeyColumn], sender.Tables[ChildTableName].Columns[ChildKeyColumn]));
        }
    }
}
