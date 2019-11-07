using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCreateEmlFiles
{
    public class DataOperations
    {
        //private string Server = @".\SQLEXPRESS";
        private string Server = "KARENS-PC";
        private string Catalog = "MockedEmail";
        private string ConnectionString = "";
        public DataOperations()
        {
            ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
        }
        public List<EmailBody> GetEmailBodies()
        {
            var bodies = new List<EmailBody>();
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT id,DisplayText,HtmlText FROM Body";
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bodies.Add(new EmailBody() { Id = reader.GetInt32(0), Text = reader.GetString(1), Body = reader.GetString(2) });
                        }
                    }
                }

                return bodies;

            }
        }
        public List<CheckListBoxItem> GetEmailAddresses()
        {
            var addresses = new List<CheckListBoxItem>();
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT [Address] FROM FakeAddresses";
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        addresses.Add(new CheckListBoxItem() { Checked = false, EmailAddress = reader.GetString(0) });
                    }
                }
            }

            return addresses;
        }
    }
}

