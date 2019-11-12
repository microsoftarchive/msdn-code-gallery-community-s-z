using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomersDataOperations;

namespace BackendUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConnectionTest()
        {
            DataOperations da = new DataOperations();
            Assert.IsTrue(da.GetAllCustomers(), "Connection failed");
        }
        [TestMethod]
        public void ReturnTableDataWithNoRecordsTest()
        {
            DataOperations da = new DataOperations();
            if (da.GetAllCustomers())
            {
                Assert.IsTrue((da.CustomerTable.Rows.Count == 0), "No records found");
            }
        }
        [TestMethod]
        public void RemoveCustomerTest()
        {
            DataOperations da = new DataOperations();
            var Identifier = 1;
            Assert.IsTrue(da.RemoveCustomer(Identifier), "Record not removed or record did not exists");
        }
    }
}
