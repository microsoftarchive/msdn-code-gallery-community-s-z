using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    internal class DataOperations
    {
        private DataTable CustomerDataTable;

        public DataTable GetCustomers()
        {
            return CustomerDataTable;
        }

        public DataOperations()
        {
            this.CustomerDataTable = new DataTable();
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT Identifier, CompanyName FROM [Customer]";
                    cn.Open();
                    this.CustomerDataTable.Load(cmd.ExecuteReader());
                }
            }
        }

        public bool AddNewCustomer(string Name, ref int NewIdentifier)
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "INSERT INTO [Customer] (CompanyName) VALUES (@CompanyName); SELECT CAST(scope_identity() AS int);";
                    cmd.Parameters.AddWithValue("@CompanyName", Name);
                    cn.Open();
                    try
                    {
                        NewIdentifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}