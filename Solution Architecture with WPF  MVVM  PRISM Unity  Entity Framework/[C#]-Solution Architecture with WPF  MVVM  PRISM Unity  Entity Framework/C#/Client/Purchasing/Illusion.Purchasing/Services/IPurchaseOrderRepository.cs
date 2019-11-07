namespace Illusion.Purchasing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// PurchaseOrder Repository Interface
    /// </summary>
    public interface IPurchaseOrderRepository
    {
        /// <summary>
        /// Gets all purchase orders.
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderEntity> GetAllPurchaseOrders();
    }
}
