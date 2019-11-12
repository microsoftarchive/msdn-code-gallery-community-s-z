using AccessConnections_cs;
using System.Data;
using System.Data.OleDb;


namespace Example_cs
{
    public class DataOperations
    {
        private string fileName = "";
        public DataOperations(string databaseFileName)
        {
            fileName = databaseFileName;
            CustomerTable = new DataTable();
        }
        public DataTable CustomerTable { get; set; }
        public void LoadCustomers()
        {
            using (OleDbConnection cn = new OleDbConnection { ConnectionString = fileName.BuildConnectionString() })
            {
                using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT CompanyName FROM Customer;";
                    DataTable dt = new DataTable { TableName = "Customer" };
                    cn.Open();
                    CustomerTable.Load(cmd.ExecuteReader());
                }
            }
        }
    }
}
