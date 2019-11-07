using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BackEnd;


namespace UnitTestData
{
    public class TestBaseData
    {
        /// <summary>
        /// See important note in ResetPeopleTable.
        /// </summary>
        public static string TestCatalog = "ApplicationTestData";
        public static string ConnectionString;
        public static string PeopleTable = "People";
        public static void SetDatabaseConnectionString()
        {
            var backEndOperations = new Operations();
            ConnectionString = $"Data Source={backEndOperations.Server};Initial Catalog={TestCatalog};Integrated Security=True";            
        }
        /// <summary>
        /// This will first remove all records from the test table then copy all rows from production people table
        /// to the test people table we just truncated. This ensures that the results are the same for each test.
        /// 
        /// IMPORTANT NOTE: In reality we would have a database setup away from the two above that would be used to
        /// populate the test database as using the production database does not really ensure we have the same data each
        /// time we run the test plus the production table may have sensitive information we don't want to expose. So for
        /// this code sample rather than introduce a third table I'm keeping it at two tables.
        /// </summary>
        /// <remarks>
        /// Notice no try/catch, this is because we are in development mode and will do no harm if we get a runtime exception
        /// as we want to know about it and not hide or attempt to send a message to the unit test class.
        /// 
        /// This method runs before each unit test so it must be fast. I could had used a MERGE but saw no noticable difference
        /// in time to execute plus MERGE is not in all editions of SQL-Server.
        /// </remarks>
        public void ResetPeopleTable()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    /*
                     * There are two statements separated with a semi-colon. First truncation then population.
                     */
                    cmd.CommandText = "TRUNCATE TABLE ApplicationTestData.dbo.People;" +
                                      "INSERT INTO ApplicationTestData.dbo.People " + 
                                      "( FirstName , LastName , Gender , BirthDay ) " + 
                                      "SELECT FirstName , LastName , Gender , BirthDay " +
                                      "FROM  ApplicationProductionData.dbo.People";

                    cn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }
        /// <summary>
        /// Find person by first and last name
        /// </summary>
        /// <param name="pFirstName"></param>
        /// <param name="pLastName"></param>
        /// <returns>true if found, false if not found</returns>
        public bool PersonExists(string pFirstName, string pLastName)
        {
            bool succcess = false;
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "SELECT  Id FROM People " + 
                                      "WHERE FirstName = @FirstName AND LastName = @LastName";

                    cmd.Parameters.AddWithValue("@FirstName", pFirstName);
                    cmd.Parameters.AddWithValue("@LastName", pLastName);
                    cn.Open();
                    succcess = !(cmd.ExecuteScalar() == null);
                }
            }
            return succcess;
        }
        /// <summary>
        /// Find person by id and return the person or a null person
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Person PersonExists(int pId)
        {
            Person foundPerson = null;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "SELECT FirstName, LastName, Gender, BirthDay FROM People " + 
                                      "WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", pId);
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        foundPerson = new Person();
                        foundPerson.Id = pId;
                        foundPerson.FirstName = reader.GetString(0);
                        foundPerson.LastName = reader.GetString(1);
                        foundPerson.Gender = reader.GetInt32(2);
                        foundPerson.BirthDay = reader.GetDateTime(3);
                    }
                }
            }
            return foundPerson;
        }
    }
}
