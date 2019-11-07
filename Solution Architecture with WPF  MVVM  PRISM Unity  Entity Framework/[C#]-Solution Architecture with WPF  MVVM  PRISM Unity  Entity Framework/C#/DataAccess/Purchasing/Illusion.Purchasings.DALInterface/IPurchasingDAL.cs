namespace Illusion.Purchasings.DALInterface
{
    using System.Collections.Generic;
    using Illusion.PurchasingsEDM;

    /// <summary>
    /// interface Vendor DAL
    /// </summary>
    public interface IVendorDAL
    {
        /// <summary>
        /// Gets all vendor.
        /// </summary>
        /// <returns></returns>
        List<Vendor> GetAllVendor();
    }

    /// <summary>
    /// interface Product Vendor DAL
    /// </summary>
    public interface IProductVendorDAL
    {
        /// <summary>
        /// Gets all product vendor.
        /// </summary>
        /// <returns></returns>
        List<ProductVendor> GetAllProductVendor();
    }

    /// <summary>
    /// Interface Vendor Contact DAL
    /// </summary>
    public interface IVendorContactDAL
    {
        /// <summary>
        /// Gets all vendor contact.
        /// </summary>
        /// <returns></returns>
        List<VendorContact> GetAllVendorContact();
    }

    /// <summary>
    /// Interface Purchase Order DAL
    /// </summary>
    public interface IPurchaseOrderDAL
    {
        /// <summary>
        /// Gets all purchase order.
        /// </summary>
        /// <returns></returns>
        List<PurchaseOrder> GetAllPurchaseOrder();
    }
}
