using Microsoft.Data.ConnectionUI;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


public class Operations
{
    /// <summary>
    /// SQL-Server name returned in GetConnection method
    /// </summary>
    public string ServerName { get; set; }
    /// <summary>
    /// SQL-Server database returned in GetConnection method
    /// </summary>
    public string InitialCatalog { get; set; }
    /// <summary>
    /// Table names in ServerName.InitialCatalog 
    /// </summary>
    public List<string> TableNames { get; set; }
    /// <summary>
    /// Create connection string using Microsoft's ConnectionUI class
    /// </summary>
    /// <param name="SaveConfiguration"></param>
    /// <returns></returns>
    public bool GetConnection(ref string DataSource, bool SaveConfiguration = false)
    {
        var success = false;

        DataConnectionDialog dcd = new DataConnectionDialog();

        DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);

        dcs.LoadConfiguration(dcd);

        if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(dcd.SelectedDataProvider.Name);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = dcd.ConnectionString;

                DataSource = connection.DataSource;
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES";

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                TableNames = dt.AsEnumerable()
                    .Select(row => row.Field<string>("table_name"))
                    .OrderBy(field => field)
                    .ToList();
            }

            var builder = new SqlConnectionStringBuilder() { ConnectionString = dcd.ConnectionString };

            ServerName = builder.DataSource;
            InitialCatalog = builder.InitialCatalog;

            if (SaveConfiguration)
            {
                dcs.SaveConfiguration(dcd);
            }

            if (TableNames.Count > 0)
            {
                success = true;
            }
        }

        return success;

    }
    /// <summary>
    /// Get column names for a table
    /// </summary>
    /// <param name="server">SQL-SERVER name</param>
    /// <param name="catalog">Initial catalog to work with</param>
    /// <param name="tableName">Existing table name in catalog</param>
    /// <returns></returns>
    public List<ColumnInformation> ColumnNameSelection(string server, string catalog, string tableName)
    {
        var information = new List<ColumnInformation>();
        var dt = new DataTable();
        var connectionString = $"Data Source={server};Initial Catalog={catalog};Integrated Security=True";

        using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
        {
            using (SqlCommand cmd = new SqlCommand { Connection = cn })
            {

                cmd.CommandText = "SELECT COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION " +
                                  "FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName;";

                cmd.Parameters.AddWithValue("@TableName", tableName);

                cn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        information.Add(new ColumnInformation()
                        {
                            Name = reader.GetString(0),
                            DataType = reader.GetString(1),
                            Position = (int)reader.GetSqlInt32(2)
                        });
                    }
                }
            }

        }

        return information;

    }
}

