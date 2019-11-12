namespace Illusion.Purchasings.DAL
{
    using System.Collections.Generic;
    using System.Data.Objects;
    using System.Linq;
    using Illusion.Purchasings.DALInterface;
    using Illusion.PurchasingsEDM;

    /// <summary>
    /// vendor DAL Class
    /// </summary>
    public class VendorDAL : IVendorDAL
    {
        /// <summary>
        /// Gets all vendor.
        /// </summary>
        /// <returns>returns Vendor</returns>
        public List<Vendor> GetAllVendor()
        {
            using (IllusionPurchasingDBEntities entites = new IllusionPurchasingDBEntities())
            {
                ObjectQuery<Vendor> vendors = entites.Vendors;
                
                vendors.MergeOption = MergeOption.NoTracking;
               
                IQueryable<Vendor> query = from vendor in vendors select vendor;
               
                List<Vendor> result = query.ToList();
                return result;
            }
        }
    }

    /// <summary>
    /// Product Vendor DAL
    /// </summary>
    public class ProductVendorDAL : IProductVendorDAL
    {
        /// <summary>
        /// Gets all product vendor.
        /// </summary>
        /// <returns>All Product Vendor</returns>
        public List<ProductVendor> GetAllProductVendor()
        {
            using (IllusionPurchasingDBEntities entites = new IllusionPurchasingDBEntities())
            {
                ObjectQuery<ProductVendor> productvendors = entites.ProductVendors;

                productvendors.MergeOption = MergeOption.NoTracking;

                IQueryable<ProductVendor> query = from vendor in productvendors select vendor;

                List<ProductVendor> result = query.ToList();
                return result;
            }
        }
    }

    /// <summary>
    /// Vendor Contact DAL
    /// </summary>
    public class VendorContactDAL : IVendorContactDAL
    {
        /// <summary>
        /// Gets all vendor contact.
        /// </summary>
        /// <returns> All Vendor Contact</returns>
        public List<VendorContact> GetAllVendorContact()
        {
            using (IllusionPurchasingDBEntities entites = new IllusionPurchasingDBEntities())
            {
                ObjectQuery<VendorContact> vendorContacts = entites.VendorContacts;

                vendorContacts.MergeOption = MergeOption.NoTracking;

                IQueryable<VendorContact> query = from contact in vendorContacts select contact;

                List<VendorContact> result = query.ToList();
                return result;
            }
        }
    }

    /// <summary>
    /// Purchase Order DAL
    /// </summary>
    public class PurchaseOrderDAL : IPurchaseOrderDAL
    {
        /// <summary>
        /// Gets all purchase order.
        /// </summary>
        /// <returns>All Purchase Order</returns>
        public List<PurchaseOrder> GetAllPurchaseOrder()
        {
            using (IllusionPurchasingDBEntities entites = new IllusionPurchasingDBEntities())
            {
                ObjectQuery<PurchaseOrder> purchaseOrders = entites.PurchaseOrders;

                purchaseOrders.MergeOption = MergeOption.NoTracking;

                IQueryable<PurchaseOrder> query = from orders in purchaseOrders select orders;

                List<PurchaseOrder> result = query.ToList();
                return result;
            }
        }
    }

}
