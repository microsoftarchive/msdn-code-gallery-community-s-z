using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd;
using Tests.CustomTraits;
using DeepEqual.Syntax;
using System.Linq;

namespace UnitTestData
{
    [TestClass]
    public class UnitTest1 : TestBaseData
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SetDatabaseConnectionString();
        }
        [TestInitialize]
        public void Init()
        {
            ResetPeopleTable();
        }
        /// <summary>
        /// Determine read operation functions as expected by
        /// validating there are 2000 records which is what is in
        /// the test repository database table. If you change the
        /// row count then of course this test will fail unless
        /// the count is updated here.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ReadRecords)]
        public void ReadAllPeopleRecords()
        {
            var ops = new Operations(TestCatalog) ;

            var dt = ops.ReadPeople();

            Assert.IsTrue(dt.Rows.Count == 2000, "Expected 2000 rows");
        }
        /// <summary>
        /// Validate removal of a record
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.DeleteRecord)]
        public void DeleteSinglePerson()
        {
            var ops = new Operations(TestCatalog);

            int personIdentifier = 10;
            string firstName = "Charlotte";
            string lastName = "Blevins";

            if (ops.RemovePerson(personIdentifier))
            {

                Assert.IsFalse(PersonExists(firstName, lastName),
                    "Expected to not find person after delete operation");

            }
            else
            {
                Assert.Fail("Expected record to have been removed");
            }
        }
        /// <summary>
        /// Test updating a single person. The assertion is done via 
        /// a NuGet package library, see readme.txt
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.UpdatRecord)]
        public void UpdateSinglePerson()
        {

            var originalPerson = new Person()
            {
                Id = 108,
                FirstName = "Jessie",
                LastName = "Swanson",
                Gender = 2,
                BirthDay = new DateTime(1992, 8, 6)
            };

            var modifiedPerson = new Person()
            {
                Id = 108,
                FirstName = "Karen",
                LastName = "Payne",
                Gender = 2,
                BirthDay = new DateTime(1989, 1, 26)
            };


            var ops = new Operations(TestCatalog);
            if (ops.UpdatePerson(modifiedPerson))
            {
                var resultPerson = PersonExists(originalPerson.Id);
                resultPerson.ShouldDeepEqual(modifiedPerson);
            }
        }
        /// <summary>
        /// Test we can add a new record
        /// * Two Asserts are used yet the first one is enough
        ///   but some may want to double check hence the second test.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        public void InsertPerson()
        {
            var ops = new Operations(TestCatalog);

            Person p = new Person()
            {
                FirstName = "Virginia",
                LastName = "Clime",
                Gender = 2,
                BirthDay = new DateTime(1920, 10, 20)
            };

            var success = ops.Add(p);
            Assert.IsTrue(success, "Failed adding person");

            if (success)
            {
                Person newPerson = PersonExists(p.Id);
                newPerson.ShouldDeepEqual(p);
            }
            else
            {
                Assert.Fail("Added record failed");
            }
        }
        /// <summary>
        /// Intended to fail
        /// I declarated it with [Ignore] so it does not run.
        /// 
        /// Comment out [Ignore], run test and it will fail because
        /// the date range is incorrect. The Date Range should be that
        /// of the test below FindPersonById_NonFailedTest.
        /// 
        /// Here is what I did, ran the following SQL SELECT in SSMS
        /// SELECT 
        ///     FirstName,
        ///     LastName 
        /// FROM 
        ///     People 
        /// WHERE 
        ///     CAST(BirthDay AS DATE) BETWEEN '1974-01-02' AND '1984-01-07'
        ///     
        /// Then when creating dates (startDate and endDate) made the error on 
        /// purpose yet it happens by incorrectly creating endDate which does 
        /// not match the end date in the BETWEEN in the above SELECT
        /// </summary>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.Search)]
        public void BetweenDates_IntendedFailingTest()
        {
            var ops = new Operations(TestCatalog);

            var startDate = new DateTime(1974, 1, 2, 1, 12, 0);
            var endDate = new DateTime(1984, 1, 2, 1, 12, 0);
            var dtPeople = ops.FindBetweenBirthDay(startDate, endDate);

            // when this test fails, the assert message will be available in the output of the
            // code-lens above the test.
            Assert.IsTrue(dtPeople.Rows.Count == 376, 
                $"Expected 376 rows but got {dtPeople.Rows.Count} rows");

        }
        [TestMethod]       
        [TestTraits(Trait.Search)]
        public void BetweenDates_NonFailedTest()
        {
            var ops = new Operations(TestCatalog);

            var startDate = new DateTime(1974, 1, 2, 1, 12, 0);
            var endDate = new DateTime(1984, 1, 7, 1, 12, 0);
            var dtPeople = ops.FindBetweenBirthDay(startDate, endDate);
            Assert.IsTrue(dtPeople.Rows.Count == 376, 
                $"Expected 376 rows but got {dtPeople.Rows.Count} rows");
        }

        #region Wrong_Testing
        /*
         * Both test check to see if there are invalid gender values where
         * valid are 1,2,3. It would be better to place a constraint on the
         * gender field in the database table.
         * 
         * Also note, the test HasValidGender_1 will take a very long time
         * to run while HasValidGender_2 will take nearly no time.
         */
        private TestContext m_testContext;
        public TestContext TestContext
        {
            get { return m_testContext; }
            set { m_testContext = value; }
        }
        [TestMethod]
        [TestTraits(Trait.BadTest)]
        [DataSource("System.Data.SqlClient", 
            "Data Source=KARENS-PC;Initial Catalog=ApplicationTestData;Integrated Security=True", 
            "People", 
            DataAccessMethod.Sequential)]
        public void HasValidGender_1()
        {
            int[] values = { 1, 2, 3 };
            int genderValue = Convert.ToInt32(TestContext.DataRow["Gender"]);
            Assert.IsTrue(values.Contains(genderValue));
        }
        [TestMethod]
        [TestTraits(Trait.BadTest)]
        public void HasValidGender_2()
        {
            var ops = new Operations(TestCatalog);
            Assert.IsTrue(ops.FindInvalidGender() == null);
        }
        #endregion
    }
}
