using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Illusion.Sales.EDM;
using Illusion.Sales.DALInterface;
using Illusion.Sales.DAL;
namespace SalesDataAccessTest
{
    [TestClass]
    public class SalesDALTest
    {
        #region Sales Test Methods
       
        [TestMethod]
        public void GetAllCustomers()
        {
            ICustomerDAL custDAL = new CustomerDAL();

            List<Customer> dummy = this.GetDummyCustomer();

            List<Customer> actual = custDAL.GetAllCustomer();

            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].CustomerID, actual[i].CustomerID);
                Assert.AreEqual(dummy[i].FirstName, actual[i].FirstName);
                Assert.AreEqual(dummy[i].LastName, actual[i].LastName);
                Assert.AreEqual(dummy[i].AddressLine1, actual[i].AddressLine1);
                Assert.AreEqual(dummy[i].City, actual[i].City);
                Assert.AreEqual(dummy[i].State, actual[i].State);
                Assert.AreEqual(dummy[i].CountryRegion, actual[i].CountryRegion);
            }

        }

        [TestMethod]
        public void GetAllContacts()
        {
            IContactDAL contDAL = new ContactDAL();

            List<Contact> dummy = this.GetDummyContact();

            List<Contact> actual = contDAL.GetAllContact();

            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].ContactID, actual[i].ContactID);
                Assert.AreEqual(dummy[i].Store, actual[i].Store);
                Assert.AreEqual(dummy[i].FirstName, actual[i].FirstName);
                Assert.AreEqual(dummy[i].LastName, actual[i].LastName);
                Assert.AreEqual(dummy[i].Title, actual[i].Title);
            }
        }

        [TestMethod]
        public void GetAllRegions()
        {
            ICountryRegionDAL regionDAL = new CountryRegionDAL();

            List<Country> dummy = this.GetDummyRegions();
            List<Country> actual = regionDAL.GetCountryRegion();

            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].CountryID, actual[i].CountryID);
                Assert.AreEqual(dummy[i].Store, actual[i].Store);
                Assert.AreEqual(dummy[i].City, actual[i].City);
                Assert.AreEqual(dummy[i].State, actual[i].State);
                Assert.AreEqual(dummy[i].CountryRegion, actual[i].CountryRegion);
            }
        }

        [TestMethod]
        public void GetAllStore()
        {
            IStoreDAL storeDal = new StoreDAL();

            List<Store> dummy = this.GetDummyStore();
            List<Store> actual = storeDal.GetAllStore();

            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].StoreID, actual[i].StoreID);
                Assert.AreEqual(dummy[i].Name, actual[i].Name);
                Assert.AreEqual(dummy[i].SalesOrderNumber, actual[i].SalesOrderNumber);
                Assert.AreEqual(dummy[i].OrderDate, actual[i].OrderDate);
                Assert.AreEqual(dummy[i].TotalDue, actual[i].TotalDue);
            }
        }
       
        #endregion Sales Test Methods

        #region Sales Dummy Data
      
        private List<Customer> GetDummyCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            Customer objCustomer = new Customer();
            objCustomer.CustomerID = 11000;
            objCustomer.FirstName = "Jon";
            objCustomer.LastName = "Yang";
            objCustomer.AddressLine1 = "3761 N. 14th St";
            objCustomer.City = "Rockhampton";
            objCustomer.State = "Queensland";
            objCustomer.CountryRegion = "Australia";
            customerList.Add(objCustomer);

            Customer objCustomer1 = new Customer();
            objCustomer1.CustomerID = 11001;
            objCustomer1.FirstName = "Eugene";
            objCustomer1.LastName = "Huang";
            objCustomer1.AddressLine1 = "2243 W St.";
            objCustomer1.City = "Seaford";
            objCustomer1.State = "Victoria";
            objCustomer1.CountryRegion = "Australia";
            customerList.Add(objCustomer1);

            return customerList;

        }

        private List<Contact> GetDummyContact()
        {
            /*
             100	A Bicycle Association	Kathleen	Winter	Owner
            101	A Bike Store	Orlando	Gee	Owner
             */
            List<Contact> contactList = new List<Contact>();
            Contact objContact = new Contact();
            objContact.ContactID = 100;
            objContact.Store = "A Bicycle Association";
            objContact.FirstName = "Kathleen";
            objContact.LastName = "Winter";
            objContact.Title = "Owner";
            contactList.Add(objContact);

            Contact objContact1 = new Contact();
            objContact1.ContactID = 101;
            objContact1.Store = "A Bike Store";
            objContact1.FirstName = "Orlando";
            objContact1.LastName = "Gee";
            objContact1.Title = "Owner";
            contactList.Add(objContact1);

            return contactList;
        }

        private List<Country> GetDummyRegions()
        {
            /*
             1	A Bike Store	Seattle	Washington	United States
            2	Progressive Sports	Renton	Washington	United States
             */
            List<Country> countryList = new List<Country>();

            Country objCountry = new Country();
            objCountry.CountryID = 1;
            objCountry.Store = "A Bike Store";
            objCountry.City = "Seattle";
            objCountry.State = "Washington";
            objCountry.CountryRegion = "United States";
            countryList.Add(objCountry);

            Country objCountry1 = new Country();
            objCountry1.CountryID = 2;
            objCountry1.Store = "Progressive Sports";
            objCountry1.City = "Renton";
            objCountry1.State = "Washington";
            objCountry1.CountryRegion = "United States";
            countryList.Add(objCountry1);
            return countryList;
        }

        private List<Store> GetDummyStore()
        {
            /*
             200	A Bike Store	SO43860	2001-08-01 00:00:00.000	14603.7393
            205	A Bike Store	SO44501	2001-11-01 00:00:00.000	26128.8674
             */
            List<Store> storeList = new List<Store>();

            Store objStore = new Store();
            objStore.StoreID = 200;
            objStore.Name = "A Bike Store";
            objStore.SalesOrderNumber = "SO43860";
            objStore.OrderDate = Convert.ToDateTime("2001-08-01 00:00:00.000");
            objStore.TotalDue = Convert.ToDecimal("14603.7393");
            storeList.Add(objStore);

            Store objStore1 = new Store();
            objStore1.StoreID = 205;
            objStore1.Name = "A Bike Store";
            objStore1.SalesOrderNumber = "SO44501";
            objStore1.OrderDate = Convert.ToDateTime("2001-11-01 00:00:00.000");
            objStore1.TotalDue = Convert.ToDecimal("26128.8674");
            storeList.Add(objStore1);
            return storeList;
        }
       
        #endregion Sales Dummy Data
    }
}
