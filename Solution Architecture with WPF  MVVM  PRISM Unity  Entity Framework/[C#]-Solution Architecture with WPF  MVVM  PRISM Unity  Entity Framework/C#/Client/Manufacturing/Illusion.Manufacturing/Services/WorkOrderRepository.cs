namespace Illusion.Manufacturing.Services
{
    using System.Collections.Generic;
    using Illusion.ManufacturingEDM;
    using Illusion.Manufacturings.BL;
    using Illusion.Manufacturings.BLInterface;
    using Illusion.UI.Entities;

    /// <summary>
    /// WorkOrder Repository Class
    /// </summary>
    public class WorkOrderRepository : IWorkOrderRepository
    {
        /// <summary>
        /// Gets all work orders.
        /// </summary>
        /// <returns>
        /// Get All WorkOrders
        /// </returns>
        public IEnumerable<WorkOrderEntity> GetAllWorkOrders()
        {
            IList<WorkOrderEntity> result = new List<WorkOrderEntity>();
            IWorkOrderBL workOrderBL = new WorkOrderBL();
            List<WorkOrder> workOrderList = workOrderBL.GetAllWorkOrder();
            foreach (WorkOrder source in workOrderList)
            {
                WorkOrderEntity target = new WorkOrderEntity();
                target.WorkOrderID = source.WorkOrderID;
                target.Product = source.Product;
                target.OrderQuantity = source.OrderQty;
                target.DueDate = source.DueDate;
                result.Add(target);
            }
            return result;
        }
    }
}
