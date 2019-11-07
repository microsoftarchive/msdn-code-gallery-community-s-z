namespace Illusion.Sales.BL
{
    using System.Collections.Generic;
    using Illusion.Sales.BLInterface;
    using Illusion.Sales.DAL;
    using Illusion.Sales.DALInterface;
    using Illusion.Sales.EDM;

    /// <summary>
    /// CustomerBL class 
    /// </summary>
    public class CustomerBL : ICustomerBL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        public List<Customer> GetAllCustomer()
        {
            ICustomerDAL customerDAL = new CustomerDAL();
            List<Customer> result = customerDAL.GetAllCustomer();
            return result;
        }
    }

    /// <summary>
    /// ContactBL class 
    /// </summary>
    public class ContactBL : IContactBL
    {
        /// <summary>
        /// Gets all contact.
        /// </summary>
        /// <returns>Get All Contact</returns>
        public List<Contact> GetAllContact()
        {
            IContactDAL contactDAL = new ContactDAL();
            List<Contact> result = contactDAL.GetAllContact();
            return result;
        }
    }

    /// <summary>
    /// StoreBL class 
    /// </summary>
    public class StoreBL : IStoreBL
    {
        /// <summary>
        /// Gets all store.
        /// </summary>
        /// <returns>Get All Store</returns>
        public List<Store> GetAllStore()
        {
            IStoreDAL storeDAL = new StoreDAL();
            List<Store> result = storeDAL.GetAllStore();
            return result;
        }
    }

    /// <summary>
    /// CountryRegionBL class 
    /// </summary>
    public class CountryRegionBL : ICountryRegionBL
    {
        /// <summary>
        /// Gets all country region.
        /// </summary>
        /// <returns>Get All Country Region</returns>
        public List<Country> GetAllCountryRegion()
        {
            ICountryRegionDAL countryRegionDAL = new CountryRegionDAL();
            List<Country> result = countryRegionDAL.GetCountryRegion();
            return result;
        }
    }
}
