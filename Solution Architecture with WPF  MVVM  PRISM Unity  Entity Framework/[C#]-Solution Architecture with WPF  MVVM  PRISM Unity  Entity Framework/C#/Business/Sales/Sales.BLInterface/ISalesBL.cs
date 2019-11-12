namespace Illusion.Sales.BLInterface
{
    using System.Collections.Generic;
    using Illusion.Sales.EDM;

    /// <summary>
    /// CustomerBL interface
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        List<Customer> GetAllCustomer();
    }

    /// <summary>
    /// ContactBL interface
    /// </summary>
    public interface IContactBL
    {
        /// <summary>
        /// Gets all contact.
        /// </summary>
        /// <returns>Get All Contact</returns>
        List<Contact> GetAllContact();
    }

    /// <summary>
    /// StoreBL interface
    /// </summary>
    public interface IStoreBL
    {
        /// <summary>
        /// Gets all store.
        /// </summary>
        /// <returns>Get All Store</returns>
        List<Store> GetAllStore();
    }

    /// <summary>
    /// CountryRegionBL class 
    /// </summary>
    public interface ICountryRegionBL
    {
        /// <summary>
        /// Gets all country region.
        /// </summary>
        /// <returns>Get All Country Region</returns>
        List<Country> GetAllCountryRegion();
    }
}
