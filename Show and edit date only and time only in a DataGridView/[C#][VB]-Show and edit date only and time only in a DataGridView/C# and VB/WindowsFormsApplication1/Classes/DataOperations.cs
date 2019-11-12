using System.Data;
using System.Data.SqlClient;

public class DataOperations
{
    /// <summary>
    /// Replace with your SQL Server name
    /// </summary>
    private string Server = "KARENS-PC";
    /// <summary>
    /// Database in which data resides, see 
    /// CreateDatabaseTableAndData.sql
    /// </summary>
    private string Catalog = "DataGridViewDateTimeColumns";
    /// <summary>
    /// Connection string for connecting to the database
    /// </summary>
    private string ConnectionString = "";


    public DataOperations()
    {
        ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
    }
    public DataTable GetRows()
    {
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
        {
            using (SqlCommand cmd = new SqlCommand { Connection = cn })
            {
                cmd.CommandText = "SELECT Identifier,RoomNumber,CheckIn,CheckOut FROM Table1";

                cn.Open();
                dt.Load(cmd.ExecuteReader());

            }
        }

        return dt;

    }
}