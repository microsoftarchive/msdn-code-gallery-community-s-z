namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.Sales.BL;
    using Illusion.Sales.BLInterface;
    using Illusion.Sales.EDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// Customer Repository class
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>Get All Customers</returns>
        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            IList<CustomerEntity> CustomersList = new List<CustomerEntity>();
            ICustomerBL _customerBL = new CustomerBL();
            foreach (Customer source in _customerBL.GetAllCustomer())
            {
                CustomerEntity target = new CustomerEntity();
                target.CustomerID = source.CustomerID;
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Address = source.AddressLine1;
                target.City = source.City;
                target.State = source.State;
                target.Country = source.CountryRegion;
                CustomersList.Add(target);
            }
            return CustomersList;
        }
    }
}
