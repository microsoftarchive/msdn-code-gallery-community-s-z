namespace AngularjsTreeView.DataAccess
{
    using DomainModel;
    using Microsoft.SqlServer.Server;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class TreeViewDataRepository : RepositoryBase, ITreeViewDataRepository
    {
        #region ITreeViewDataRepository Members

        public IList<TreeViewNode> GetAllTreeViewNodes()
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand("dbo.GetTreeViewData", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            var resultList = new List<TreeViewNode>();

            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new TreeViewNode();

                        item.Id = int.Parse(reader["Id"].ToString());
                        item.ParentId = reader["ParentId"].TryParseToInt();
                        item.NodeName = reader["NodeName"].ToString();

                        resultList.Add(item);
                    }
                }
            }

            finally
            {
                sqlConnection.Close();
            }

            return resultList;
        }

        public void Update(IList<TreeViewNode> treeViewNodes)
        {
            var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand("dbo.UpdateTreeViewData", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add("@p_TreeViewData", SqlDbType.Structured);
            var list = new List<SqlDataRecord>();

            foreach (var treeViewNode in treeViewNodes)
            {
                var sqlDataRecord = new SqlDataRecord(
                    new SqlMetaData("Id", SqlDbType.Int),
                    new SqlMetaData("ParentId", SqlDbType.Int),
                    new SqlMetaData("NodeName", SqlDbType.NVarChar, 50),
                    new SqlMetaData("IsSelected", SqlDbType.Bit));

                sqlDataRecord.SetValue(0, treeViewNode.Id);
                sqlDataRecord.SetValue(1, treeViewNode.ParentId);
                sqlDataRecord.SetString(2, treeViewNode.NodeName);
                sqlDataRecord.SetValue(3, treeViewNode.IsSelected);

                list.Add(sqlDataRecord);
            }
            
            sqlCommand.Parameters["@p_TreeViewData"].Value = list;

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        #endregion
    }
}