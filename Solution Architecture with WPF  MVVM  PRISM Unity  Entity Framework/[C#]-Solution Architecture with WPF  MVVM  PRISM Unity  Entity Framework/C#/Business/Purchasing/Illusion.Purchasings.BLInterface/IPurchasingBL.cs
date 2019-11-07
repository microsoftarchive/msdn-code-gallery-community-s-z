namespace Illusion.Purchasings.BLInterface
{
    using System.Collections.Generic;
    using Illusion.PurchasingsEDM;

    /// <summary>
    /// interface Vendor BL
    /// </summary>
    public interface IVendorBL
    {
        /// <summary>
        /// Gets all vendor.
        /// </summary>
        /// <returns>Get All Vendor</returns>
        List<Vendor> GetAllVendor();
    }

    /// <summary>
    /// interface Product Vendor BL
    /// </summary>
    public interface IProductVendorBL
    {
        /// <summary>
        /// Gets all product vendor.
        /// </summary>
        /// <returns>Get All ProductVendor</returns>
        List<ProductVendor> GetAllProductVendor();
    }

    /// <summary>
    /// Interface Vendor Contact BL
    /// </summary>
    public interface IVendorContactBL
    {
        /// <summary>
        /// Gets all vendor contact.
        /// </summary>
        /// <returns>Get All VendorContact</returns>
        List<VendorContact> GetAllVendorContact();
    }

    /// <summary>
    /// Interface Purchase Order BL
    /// </summary>
    public interface IPurchaseOrderBL
    {
        /// <summary>
        /// Gets all purchase order.
        /// </summary>
        /// <returns>Get All PurchaseOrder</returns>
        List<PurchaseOrder> GetAllPurchaseOrder();
    }
}
