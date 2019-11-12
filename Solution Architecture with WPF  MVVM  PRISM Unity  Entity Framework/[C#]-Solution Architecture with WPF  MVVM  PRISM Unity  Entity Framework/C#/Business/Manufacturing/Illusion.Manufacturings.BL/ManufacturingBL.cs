namespace Illusion.Manufacturings.BL
{
    using System.Collections.Generic;
    using Illusion.ManufacturingEDM;
    using Illusion.Manufacturings.BLInterface;
    using Illusion.Manufacturings.DAL;
    using Illusion.Manufacturings.DALInterface;

    /// <summary>
    /// class Bill Of Material BL
    /// </summary>
    public class BillOfMaterialBL : IBillOfMaterialBL
    {
        /// <summary>
        /// Gets all bill of material.
        /// </summary>
        /// <returns>Get All BillOfMaterial</returns>
        public List<BillOfMaterial> GetAllBillOfMaterial()
        {
            IBillOfMaterialDAL billofMaterialDAL = new BillOfMaterialDAL();
            List<BillOfMaterial> result = billofMaterialDAL.GetAllBillOfMaterial();
            return result;
        }
    }

    /// <summary>
    /// class Product Inventory BL
    /// </summary>
    public class ProductInventoryBL : IProductInventoryBL
    {
        /// <summary>
        /// Gets all product inventory.
        /// </summary>
        /// <returns>Get All ProductInventory</returns>
        public List<ProductInventory> GetAllProductInventory()
        {
            IProductInventoryDAL productInventoryDAL = new ProductInventoryDAL();
            List<ProductInventory> result = productInventoryDAL.GetAllProductInventory();
            return result;
        }
    }

    /// <summary>
    /// class Work Order BL
    /// </summary>
    public class WorkOrderBL : IWorkOrderBL
    {
        /// <summary>
        /// Gets all work order.
        /// </summary>
        /// <returns>Get All WorkOrder</returns>
        public List<WorkOrder> GetAllWorkOrder()
        {
            IWorkOrderDAL workOrderDAL = new WorkOrderDAL();
            List<WorkOrder> result = workOrderDAL.GetAllWorkOrder();
            return result;
        }
    }

}
