namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;
    /// <summary>
    /// Vendor Respository Interface
    /// </summary>
    public interface IVendorRepository
    {
        /// <summary>
        /// Gets all vendors.
        /// </summary>
        /// <returns>Get All Vendors</returns>
        IEnumerable<VendorEntity> GetAllVendors();
    }
}
