namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// Customer Repository interface
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CustomerEntity> GetAllCustomers();
    }
}
