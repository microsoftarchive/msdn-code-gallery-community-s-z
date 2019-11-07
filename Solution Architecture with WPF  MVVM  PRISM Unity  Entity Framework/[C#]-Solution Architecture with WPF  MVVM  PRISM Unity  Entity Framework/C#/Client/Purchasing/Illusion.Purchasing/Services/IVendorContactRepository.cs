namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// VendorContact Repository interface
    /// </summary>
    public interface IVendorContactRepository
    {
        /// <summary>
        /// Gets all vendor contacts.
        /// </summary>
        /// <returns>Get All Vendor Contacts</returns>
        IEnumerable<VendorContactEntity> GetAllVendorContacts();
    }
}
