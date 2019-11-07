namespace Illusion.Manufacturing.Services
{
    using System.Collections.Generic;
    using Illusion.ManufacturingEDM;
    using Illusion.Manufacturings.BL;
    using Illusion.Manufacturings.BLInterface;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductInventory Repository class
    /// </summary>
    public class ProductInventoryRepository : IProductInventoryRepository
    {
        /// <summary>
        /// Gets all product inventories.
        /// </summary>
        /// <returns>
        /// Get All ProductInventories
        /// </returns>
        public IEnumerable<ProductInventoryEntity> GetAllProductInventories()
        {
            IList<ProductInventoryEntity> result = new List<ProductInventoryEntity>();
            IProductInventoryBL productInventoryBL = new ProductInventoryBL();
            List<ProductInventory> productInventoryList = productInventoryBL.GetAllProductInventory();
            foreach (ProductInventory source in productInventoryList)
            {
                ProductInventoryEntity target = new ProductInventoryEntity();
                target.ProductInventoryID = source.ProductInventoryID;
                target.Product = source.Product;
                target.InventoryLocation = source.Inventory_Location;
                target.QtyAvailable = source.Qty_Available;
                result.Add(target);
            }
            return result;
        }
    }
}
