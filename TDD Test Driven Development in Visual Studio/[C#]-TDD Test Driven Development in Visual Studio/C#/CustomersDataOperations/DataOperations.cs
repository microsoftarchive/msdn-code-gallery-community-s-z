using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CustomersDataOperations
{ 
    public class DataOperations
    {
        private string ConnectionString = $@"Data Source=(LocalDB)\v11.0;AttachDbFilename={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory)}\Customers_TDD.mdf;Integrated Security=True;Connect Timeout=3";
        public DataTable CustomerTable  { get; set; }
        public bool GetAllCustomers()
        {
            CustomerTable = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = "SELECT * FROM Customers" })
                {
                    try
                    {
                        cn.Open();
                        CustomerTable.Load(cmd.ExecuteReader());
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
        }

        public bool RemoveCustomer(int identifier)
        {
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = "DELETE FROM Customers WHERE ID = @ID" })
                {
                    cmd.Parameters.AddWithValue("@ID", identifier);
                    try
                    {
                        cn.Open();

                        return (cmd.ExecuteNonQuery() > 0);
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
