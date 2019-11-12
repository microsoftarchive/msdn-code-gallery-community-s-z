namespace Illusion.Manufacturings.DALInterface
{
    using System.Collections.Generic;
    using Illusion.ManufacturingEDM;

    /// <summary>
    /// BillOfMaterialDAL interface
    /// </summary>
    public interface IBillOfMaterialDAL
    {
        /// <summary>
        /// Gets all bill of material.
        /// </summary>
        /// <returns>Get All BillOfMaterial</returns>
        List<BillOfMaterial> GetAllBillOfMaterial();
    }

    /// <summary>
    /// ProductInventoryDAL interface
    /// </summary>
    public interface IProductInventoryDAL
    {
        /// <summary>
        /// Gets all product inventory.
        /// </summary>
        /// <returns>Get All ProductInventory</returns>
        List<ProductInventory> GetAllProductInventory();
    }

    /// <summary>
    /// WorkOrderDAL interface
    /// </summary>
    public interface IWorkOrderDAL
    {
        /// <summary>
        /// Gets all work order.
        /// </summary>
        /// <returns>Get All WorkOrder</returns>
        List<WorkOrder> GetAllWorkOrder();
    }
}
