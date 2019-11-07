namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.Purchasings.BL;
    using Illusion.Purchasings.BLInterface;
    using Illusion.PurchasingsEDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// PurchaseOrder Repository class
    /// </summary>
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        /// <summary>
        /// Gets all purchase orders.
        /// </summary>
        /// <returns>Get All Purchase Orders</returns>
        public IEnumerable<PurchaseOrderEntity> GetAllPurchaseOrders()
        {
            IList<PurchaseOrderEntity> result = new List<PurchaseOrderEntity>();
            IPurchaseOrderBL purchaseOrderBL = new PurchaseOrderBL();
            List<PurchaseOrder> purchaseOrderList = purchaseOrderBL.GetAllPurchaseOrder();
            foreach (PurchaseOrder source in purchaseOrderList)
            {
                PurchaseOrderEntity target = new PurchaseOrderEntity();
                target.PurchaseOrderID = source.PurchaseOrderID;
                target.Vendor = source.Vendor;
                target.TotalPurchase = source.Total_Purchase;
                target.AveragePurchase = source.Average_Purchase;
                target.MinimumPurchase = source.Minimum_Purchase;
                target.MaximumPurchase = source.Maximum_Purchase;
                result.Add(target);
            }
            return result;
        }
    }
}
