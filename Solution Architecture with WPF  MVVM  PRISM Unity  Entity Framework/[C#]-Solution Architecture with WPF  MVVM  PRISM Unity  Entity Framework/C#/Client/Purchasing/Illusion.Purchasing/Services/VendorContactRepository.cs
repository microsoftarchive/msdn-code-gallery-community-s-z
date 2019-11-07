namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.Purchasings.BL;
    using Illusion.Purchasings.BLInterface;
    using Illusion.PurchasingsEDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// VendorContact Repository class
    /// </summary>
    public class VendorContactRepository : IVendorContactRepository
    {
        /// <summary>
        /// Gets all vendor contacts.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendorContactEntity> GetAllVendorContacts()
        {
            IList<VendorContactEntity> result = new List<VendorContactEntity>();
            IVendorContactBL vendorContactBL = new VendorContactBL();
            List<VendorContact> vendorContactList = vendorContactBL.GetAllVendorContact();
            foreach (VendorContact source in vendorContactList)
            {
                VendorContactEntity target = new VendorContactEntity();
                target.VendorContactID = source.VendorContactID;
                target.Vendor = source.Vendor;
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Title = source.Title;
                result.Add(target);
            }
            return result;
        }
    }
}
