namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.Purchasings.BL;
    using Illusion.Purchasings.BLInterface;
    using Illusion.PurchasingsEDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// Vendor Respository class
    /// </summary>
    public class VendorRepository : IVendorRepository
    {
        /// <summary>
        /// Gets all vendors.
        /// </summary>
        /// <returns>
        /// Get All Vendors
        /// </returns>
        public IEnumerable<VendorEntity> GetAllVendors()
        {
            IList<VendorEntity> result = new List<VendorEntity>();
            IVendorBL vendorBL = new VendorBL();
            List<Vendor> vendorList = vendorBL.GetAllVendor();
            foreach (Vendor source in vendorList)
            {
                VendorEntity target = new VendorEntity();
                target.VendorID = source.VendorID;
                target.Vendor = source.Vendor1;
                target.Address = source.AddressLine1;
                target.City = source.City;
                target.State = source.State;
                target.Country = source.Country;
                result.Add(target);
            }
            return result;
        }
    }
}
