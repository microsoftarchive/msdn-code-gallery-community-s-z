using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public class DataOperations
    {
        /// <summary>
        /// Get distinct contact titles which we store in 
        /// a private list in our main form for use in the edit form.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// No exception handling but if you feel more comfortable with
        /// it feel free to add a try-catch to the code below. Generally
        /// speaking I use exception handling but left it out for clarity.
        /// </remarks>
        public List<string> ContactTitles()
        {
            var titleList = new List<string>();
            
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT DISTINCT ContactTitle FROM Customers";
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        titleList.Add(reader.GetString(0));
                    }
                }

            }

            return titleList;

        }
        public Dictionary<int, string> Standings()
        {
            var dic = new Dictionary<int, string>();
            using (SqlConnection cn = new SqlConnection { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT id,Color FROM CustomerType";
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dic.Add(reader.GetInt32(0),reader.GetString(1));
                    }
                }
            }

            return dic;
        }
    }
}
