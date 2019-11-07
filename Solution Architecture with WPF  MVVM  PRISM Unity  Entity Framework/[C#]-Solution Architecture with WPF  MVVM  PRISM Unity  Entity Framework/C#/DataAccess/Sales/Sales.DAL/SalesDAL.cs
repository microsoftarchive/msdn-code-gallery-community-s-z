namespace Illusion.Sales.DAL
{
    using System.Collections.Generic;
    using System.Data.Objects;
    using System.Linq;
    using Illusion.Sales.DALInterface;
    using Illusion.Sales.EDM;

    /// <summary>
    /// ContactDAL class 
    /// </summary>
    public class ContactDAL : IContactDAL
    {
        /// <summary>
        /// Gets all contact.
        /// </summary>
        /// <returns>Get All Contact</returns>
        public List<Contact> GetAllContact()
        {
            using (IllusionSalesDBEntities entities = new IllusionSalesDBEntities())
            {
                //returns entities from conceptual model
                ObjectQuery<Contact> contacts = entities.Contacts;

                //objects are maintained in a detached state and are not tracked in the ObjectStateManager;
                contacts.MergeOption = MergeOption.NoTracking;

                //queries against a specific data source where in the type of the data is known
                IQueryable<Contact> query = from contact in contacts select contact;

                //materialized the result
                List<Contact> result = query.ToList();
                return result;
            }
        }
    }

    /// <summary>
    /// StoreDAL class
    /// </summary>
    public class StoreDAL : IStoreDAL
    {
        /// <summary>
        /// Gets all store.
        /// </summary>
        /// <returns>Get All Store</returns>
        public List<Store> GetAllStore()
        {
            using (IllusionSalesDBEntities entites = new IllusionSalesDBEntities())
            {
                //returns entities from the conceptual model
                ObjectQuery<Store> stores = entites.Stores;

                //objects are maintained in a detached state and are not tracked in the ObjectStateManager;
                stores.MergeOption = MergeOption.NoTracking;

                //queries against a specific data source where in the type of the data is known
                IQueryable<Store> query = from store in stores select store;

                //Materialized result
                List<Store> result = query.ToList();
                return result;
            }
        }
    }

    /// <summary>
    /// CustomerDAL class 
    /// </summary>
    public class CustomerDAL : ICustomerDAL
    {
        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>Get All Customer</returns>
        public List<Customer> GetAllCustomer()
        {
            using (IllusionSalesDBEntities entities = new IllusionSalesDBEntities())
            {
                //returns entities from conceptual model
                ObjectQuery<Customer> customers = entities.Customers;

                //objects are maintained in a detached state and are not tracked in the ObjectStateManager;
                customers.MergeOption = MergeOption.NoTracking;

                //queries against a specific data source where in the type of the data is known
                IQueryable<Customer> query = from cust in customers select cust;

                //Materialized result
                List<Customer> customerList = query.ToList();
                return customerList;
            }
        }
    }

    /// <summary>
    /// CountryRegionDAL class 
    /// </summary>
    public class CountryRegionDAL : ICountryRegionDAL
    {
        /// <summary>
        /// Gets the country region.
        /// </summary>
        /// <returns>Get Country Region</returns>
        public List<Country> GetCountryRegion()
        {
            using (IllusionSalesDBEntities entities = new IllusionSalesDBEntities())
            {
                //returns Country entities from the conceptual model
                ObjectQuery<Country> regions = entities.Countries;

                //objects are maintained in a detached state and are not tracked in the ObjectStateManager;
                regions.MergeOption = MergeOption.NoTracking;

                //queries against a specific data source where in the type of the data is known
                IQueryable<Country> query = from region in regions select region;

                //Materialized Country result
                List<Country> result = query.ToList();
                return result;
            }
        }
    }
}
