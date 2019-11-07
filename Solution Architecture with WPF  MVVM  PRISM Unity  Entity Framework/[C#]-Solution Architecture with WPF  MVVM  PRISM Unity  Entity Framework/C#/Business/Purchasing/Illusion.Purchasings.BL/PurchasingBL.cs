namespace Illusion.Purchasings.BL
{
    using System.Collections.Generic;
    using Illusion.Purchasings.BLInterface;
    using Illusion.Purchasings.DAL;
    using Illusion.Purchasings.DALInterface;
    using Illusion.PurchasingsEDM;

    /// <summary>
    /// VendorBL class
    /// </summary>
    public class VendorBL : IVendorBL
    {
        /// <summary>
        /// Gets all vendor.
        /// </summary>
        /// <returns>Get All Vendor</returns>
        public List<Vendor> GetAllVendor()
        {
            IVendorDAL vendorDAL = new VendorDAL();
            List<Vendor> result = vendorDAL.GetAllVendor();
            return result;
        }
    }


    /// <summary>
    /// ProductVendorBL class 
    /// </summary>
    public class ProductVendorBL : IProductVendorBL
    {
        /// <summary>
        /// Gets all product vendor.
        /// </summary>
        /// <returns>Get All ProductVendor</returns>
        public List<ProductVendor> GetAllProductVendor()
        {
            IProductVendorDAL productVendorDAL = new ProductVendorDAL();
            List<ProductVendor> result = productVendorDAL.GetAllProductVendor();
            return result;
        }
    }

    /// <summary>
    /// PurchaseOrderBL class 
    /// </summary>
    public class PurchaseOrderBL : IPurchaseOrderBL
    {
        /// <summary>
        /// Gets all purchase order.
        /// </summary>
        /// <returns>Get All PurchaseOrder</returns>
        public List<PurchaseOrder> GetAllPurchaseOrder()
        {
            PurchaseOrderDAL purchaseOrderDAL = new PurchaseOrderDAL();
            List<PurchaseOrder> result = purchaseOrderDAL.GetAllPurchaseOrder();
            return result;
        }
    }

    /// <summary>
    /// VendorContactBL class 
    /// </summary>
    public class VendorContactBL : IVendorContactBL
    {
        /// <summary>
        /// Gets all vendor contact.
        /// </summary>
        /// <returns>Get All VendorContact</returns>
        public List<VendorContact> GetAllVendorContact()
        {
            IVendorContactDAL vendorContactDAL = new VendorContactDAL();
            List<VendorContact> result = vendorContactDAL.GetAllVendorContact();
            return result;
        }
    }

}
