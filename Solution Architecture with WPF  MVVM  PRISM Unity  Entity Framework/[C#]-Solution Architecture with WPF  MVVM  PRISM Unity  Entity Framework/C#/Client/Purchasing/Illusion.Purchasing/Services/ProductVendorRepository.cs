namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.Purchasings.BL;
    using Illusion.Purchasings.BLInterface;
    using Illusion.PurchasingsEDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductVendor Repository class
    /// </summary>
    public class ProductVendorRepository : IProductVendorRepository
    {
        /// <summary>
        /// Gets all product vendors.
        /// </summary>
        /// <returns>Get All Product Vendors</returns>
        public IEnumerable<ProductVendorEntity> GetAllProductVendors()
        {
            IList<ProductVendorEntity> result = new List<ProductVendorEntity>();
            IProductVendorBL productVendorBL = new ProductVendorBL();
            List<ProductVendor> productVendorList = productVendorBL.GetAllProductVendor();
            foreach (ProductVendor soure in productVendorList)
            {
                ProductVendorEntity target = new ProductVendorEntity();
                target.ProductVendorID = soure.ProductVendorID;
                target.ProductNumber = soure.ProductNumber;
                target.Product = soure.Product;
                target.Vendor = soure.Vendor;
                target.LastReceiptCost = soure.LastReceiptCost;
                result.Add(target);
            }
            return result;
        }
    }
}
