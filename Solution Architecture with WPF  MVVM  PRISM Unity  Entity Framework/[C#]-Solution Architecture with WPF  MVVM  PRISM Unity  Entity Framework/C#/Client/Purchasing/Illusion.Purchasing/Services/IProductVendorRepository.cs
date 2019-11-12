namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductVendor Repository interface
    /// </summary>
    public interface IProductVendorRepository
    {
        /// <summary>
        /// Gets all product vendors.
        /// </summary>
        /// <returns>Get All Product Vendors</returns>
        IEnumerable<ProductVendorEntity> GetAllProductVendors();
    }
}
