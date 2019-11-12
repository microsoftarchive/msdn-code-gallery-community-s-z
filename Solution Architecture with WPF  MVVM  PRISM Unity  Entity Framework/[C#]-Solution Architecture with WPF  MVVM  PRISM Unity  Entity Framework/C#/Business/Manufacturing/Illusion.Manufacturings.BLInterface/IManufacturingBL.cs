namespace Illusion.Manufacturings.BLInterface
{
    using System.Collections.Generic;
    using Illusion.ManufacturingEDM;

    /// <summary>
    /// Interface BillOfMaterialBL
    /// </summary>
    public interface IBillOfMaterialBL
    {
        /// <summary>
        /// Gets all bill of material.
        /// </summary>
        /// <returns>Get All BillOfMaterial</returns>
        List<BillOfMaterial> GetAllBillOfMaterial();
    }

    /// <summary>
    /// Interface IProductInventoryBL
    /// </summary>
    public interface IProductInventoryBL
    {
        /// <summary>
        /// Gets all product inventory.
        /// </summary>
        /// <returns>Get All ProductInventory</returns>
        List<ProductInventory> GetAllProductInventory();
    }

    /// <summary>
    /// Interface IWorkOrderBL
    /// </summary>
    public interface IWorkOrderBL
    {
        /// <summary>
        /// Gets all work order.
        /// </summary>
        /// <returns>Get All WorkOrder</returns>
        List<WorkOrder> GetAllWorkOrder();
    }
}
