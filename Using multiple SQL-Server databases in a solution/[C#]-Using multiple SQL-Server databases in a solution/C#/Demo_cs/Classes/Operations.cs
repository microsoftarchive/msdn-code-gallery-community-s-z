using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Demo_cs
{
    public class Operations
    {
        /// <summary>
        /// SQL-Server server name
        /// </summary>
        private string ServerName;
        /// <summary>
        /// Connection string to the customer database
        /// </summary>
        private string ConnectionString;
        /// <summary>
        /// Connection string to the City and State database
        /// </summary>
        private string ReferenceConnectionString;
        public bool HasErrors { get; set; }
        public string ExceptionMessage { get; set; }
        public DataTable CustomersTable;
        public List<State> States;
        public List<City> Cities;

        public Operations()
        {
            /*
             * IMPORTANT: You must change the server name to your server name.
             */
ServerName = "KARENS-PC";

ConnectionString = $"Data Source={ServerName};Initial Catalog=CustomersForCodeSample;Integrated Security=True";
ReferenceConnectionString = $"Data Source={ServerName};Initial Catalog=CityStateReferences;Integrated Security=True";

        }
        /// <summary>
        /// Return all states from the database into a list
        /// </summary>
        /// <returns></returns>
        public bool GetStates()
        {
            var success = false;
            States = new List<State>();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ReferenceConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT StateIdentifier,Name FROM US_States";
                    try
                    {
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        States.Add(new State { StateIdentifier = 0, Name = "Select one" });
                        while (reader.Read())
                        {
                            States.Add(new State { StateIdentifier = reader.GetInt32(0), Name = reader.GetString(1) });
                        }

                        success = true;
                    }
                    catch (Exception ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                    }
                }
            }

            return success;

        }
        /// <summary>
        /// Return all cities from the database with city and state identifiers
        /// </summary>
        /// <returns></returns>
        public bool GetCities()
        {
            var success = false;
            Cities = new List<City>();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ReferenceConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT CityIdentifier, StateIdentifier, CityName FROM US_Cities";
                    try
                    {
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Cities.Add(new City { CityIdentifier = reader.GetInt32(0), StateIdentifier = reader.GetInt32(1), Name = reader.GetString(2) });
                        }

                        Cities = Cities.OrderBy(item => item.Name).ToList();
                        Cities.Insert(0, new City { CityIdentifier = 0, Name = "Select one", StateIdentifier = 0 });
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                    }
                }
            }

            return success;

        }
        /// <summary>
        /// Return all cutomers using two databases
        /// </summary>
        /// <returns></returns>
        public bool GetCustomers()
        {
            var success = false;
            CustomersTable = new DataTable();
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn})
                {

                    cmd.CommandText = @"
                        SELECT  C.id,
                                C.FirstName ,
                                C.LastName ,
                                C.CityIdentifier ,
                                C.StateIdentifer ,
                                uc.CityName AS City ,
                                us.Name AS State 
                        FROM    Customers AS C
                                LEFT OUTER JOIN CityStateReferences.dbo.US_States AS us ON C.StateIdentifer = us.StateIdentifier
                                LEFT OUTER JOIN CityStateReferences.dbo.US_Cities AS uc ON uc.CityIdentifier = C.CityIdentifier";

                    try
                    {
                        cn.Open();

                        CustomersTable.Load(cmd.ExecuteReader());

                        // field we want but not to show in the user interface
                        CustomersTable.Columns["id"].ColumnMapping = MappingType.Hidden;
                        CustomersTable.Columns["StateIdentifer"].ColumnMapping = MappingType.Hidden;
                        CustomersTable.Columns["CityIdentifier"].ColumnMapping = MappingType.Hidden;

                        // better to perform sort on client side
                        CustomersTable.DefaultView.Sort = "LastName";
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                    }

                }
            }

            return success;

        }
        /// <summary>
        /// Add a new cutomer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddCustomer(ref Customer customer)
        {
            var success = false;
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = 
                        "INSERT INTO Customers (FirstName,LastName,StateIdentifer,CityIdentifier)  " + 
                        "VALUES (@FirstName,@LastName,@StateIdentifer,@CityIdentifier)";

                    try
                    {
                        cn.Open();

                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@StateIdentifer", customer.StateIdentifer);
                        cmd.Parameters.AddWithValue("@CityIdentifier", customer.CityIdentifier);

                        int result = cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            cmd.CommandText = "Select @@Identity";
                            customer.id = Convert.ToInt32(cmd.ExecuteScalar());
                            success = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        HasErrors = true;
                        ExceptionMessage = ex.Message;
                    }
                }
            }

            return success;

        }
    }
}
