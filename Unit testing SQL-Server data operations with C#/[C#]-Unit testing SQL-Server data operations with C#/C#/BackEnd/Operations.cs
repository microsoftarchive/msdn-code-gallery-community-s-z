using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BackEnd
{
    public class Operations
    {
        /// <summary>
        /// Replace with your SQL Server name
        /// </summary>
        public string Server = "KARENS-PC";
        /// <summary>
        /// Database in which data resides, see SQL_Script.sql
        /// </summary>
        public string Catalog = "ApplicationProductionData";
        /// <summary>
        /// Connection string for connecting to the database
        /// </summary>
        private string ConnectionString = "";
        /// <summary>
        /// Setup the connection string
        /// </summary>
        public Operations()
        {
            ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
        }
        public Operations(string pCatalog)
        {
            ConnectionString = $"Data Source={Server};Initial Catalog={pCatalog};Integrated Security=True";
        }
        /// <summary>
        /// Read all people without any sorting or filtering
        /// </summary>
        /// <returns></returns>
        public DataTable ReadPeople()
        {
            var dtPeople = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT Id,FirstName,LastName,Gender,BirthDay  FROM People";
                    cn.Open();
                    dtPeople.Load(cmd.ExecuteReader());
                }
            }

            return dtPeople;
        }
        public DataTable FindBetweenBirthDay(DateTime pStartDate, DateTime pEndDate)
        {
            var dtPeople = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT FirstName,LastName FROM People " +
                                      "WHERE CAST(BirthDay AS DATE) BETWEEN @StartDate AND @EndDate";

                    cmd.Parameters.AddWithValue("@StartDate", pStartDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate.Date);

                    cn.Open();
                    dtPeople.Load(cmd.ExecuteReader());
                }
            }

            return dtPeople;
        }
        public List<int> FindInvalidGender()
        {
            List<int> invalidList = null;
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT Id FROM ApplicationTestData.dbo.People  WHERE Gender NOT IN (1,2,3)";
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        invalidList = new List<int>();
                        while (reader.Read())
                        {
                            invalidList.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return invalidList;
        }
        /// <summary>
        /// Remove person by id
        /// </summary>
        /// <param name="pIdentifier">Person key</param>
        /// <returns></returns>
        public bool RemovePerson(int pIdentifier)
        {
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "DELETE FROM People WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pIdentifier);
                    cn.Open();
                    succcess = (cmd.ExecuteNonQuery() == 1);
                }
            }

            return succcess;
        }
        public bool UpdatePerson(Person pPerson)
        {
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "UPDATE People " + 
                                      "SET " + 
                                      "FirstName = @FirstName," + 
                                      "LastName = @LastName, " + 
                                      "Gender = @Gender," + 
                                      "BirthDay = @BirthDay " + 
                                      "WHERE Id = @Id";


                    cmd.Parameters.AddWithValue("@FirstName", pPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pPerson.LastName);
                    cmd.Parameters.AddWithValue("@Gender", pPerson.Gender);
                    cmd.Parameters.AddWithValue("@BirthDay", pPerson.BirthDay);
                    cmd.Parameters.AddWithValue("@Id", pPerson.Id);

                    cn.Open();

                  
                    
                    succcess = (cmd.ExecuteNonQuery() == 1);

                }
            }

            return succcess;
        }
        public bool Add(Person pPerson)
        {
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    // insert statement followed by select to get new primary key
                    cmd.CommandText = "INSERT INTO dbo.People (FirstName,LastName,Gender,BirthDay) VALUES (@FirstName,@LastName,@Gender,@BirthDay)" +
                                      ";SELECT CAST(scope_identity() AS int);";


                    cmd.Parameters.AddWithValue("@FirstName", pPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pPerson.LastName);
                    cmd.Parameters.AddWithValue("@Gender", pPerson.Gender);
                    cmd.Parameters.AddWithValue("@BirthDay", pPerson.BirthDay);

                    cn.Open();

                    try
                    {
                        pPerson.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        succcess = true;
                    }
                    catch (Exception)
                    {
                        succcess = false;
                    }
                }
            }

            return succcess;
        }
        public Person FindByIdentifier(int pIdentifier)
        {
            return new Person();
        }
    }
}
