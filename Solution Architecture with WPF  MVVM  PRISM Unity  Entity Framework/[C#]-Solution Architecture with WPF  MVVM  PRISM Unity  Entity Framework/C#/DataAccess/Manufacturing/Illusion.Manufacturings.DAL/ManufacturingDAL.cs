namespace Illusion.Manufacturings.DAL
{
    using System.Collections.Generic;
    using System.Data.Objects;
    using System.Linq;
    using Illusion.ManufacturingEDM;
    using Illusion.Manufacturings.DALInterface;

    /// <summary>
    /// BillOfMaterialDAL class 
    /// </summary>
    public class BillOfMaterialDAL : IBillOfMaterialDAL
    {
        /// <summary>
        /// Gets all bill of material.
        /// </summary>
        /// <returns>Get All BillOfMaterial</returns>
        public List<BillOfMaterial> GetAllBillOfMaterial()
        {
            using (IllusionManufacturingDBEntities entites = new IllusionManufacturingDBEntities())
            {
                ObjectQuery<BillOfMaterial> billOfMaterials = entites.BillOfMaterials;

                billOfMaterials.MergeOption = MergeOption.NoTracking;

                IQueryable<BillOfMaterial> query = from bill in billOfMaterials select bill;

                List<BillOfMaterial> result = query.ToList();

                return result;
            }
        }
    }

    /// <summary>
    /// ProductInventoryDAL class 
    /// </summary>
    public class ProductInventoryDAL : IProductInventoryDAL
    {
        /// <summary>
        /// Gets all product inventory.
        /// </summary>
        /// <returns>Get All ProductInventory</returns>
        public List<ProductInventory> GetAllProductInventory()
        {
            using (IllusionManufacturingDBEntities entites = new IllusionManufacturingDBEntities())
            {
                ObjectQuery<ProductInventory> productInventories = entites.ProductInventories;

                productInventories.MergeOption = MergeOption.NoTracking;

                IQueryable<ProductInventory> query = from inventory in productInventories select inventory;

                List<ProductInventory> result = query.ToList();

                return result;
            }
        }
    }


    /// <summary>
    /// WorkOrderDAL class 
    /// </summary>
    public class WorkOrderDAL : IWorkOrderDAL
    {
        /// <summary>
        /// Gets all work order.
        /// </summary>
        /// <returns>Get All WorkOrder</returns>
        public List<WorkOrder> GetAllWorkOrder()
        {
            using (IllusionManufacturingDBEntities entites = new IllusionManufacturingDBEntities())
            {
                ObjectQuery<WorkOrder> workOrders = entites.WorkOrders;

                workOrders.MergeOption = MergeOption.NoTracking;

                IQueryable<WorkOrder> query = from orders in workOrders select orders;

                List<WorkOrder> result = query.ToList();

                return result;
            }
        }
    }
 
}
