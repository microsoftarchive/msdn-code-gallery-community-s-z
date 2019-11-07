namespace Illusion.Manufacturing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductInventory Repository interface
    /// </summary>
    public interface IProductInventoryRepository
    {
        /// <summary>
        /// Gets all product inventories.
        /// </summary>
        /// <returns>Get All ProductInventories</returns>
        IEnumerable<ProductInventoryEntity> GetAllProductInventories();
    }
}
