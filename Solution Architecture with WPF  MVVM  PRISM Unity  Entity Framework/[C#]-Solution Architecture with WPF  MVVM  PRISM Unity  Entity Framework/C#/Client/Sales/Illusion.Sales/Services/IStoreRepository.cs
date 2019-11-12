namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// Store Repository interface
    /// </summary>
    public interface IStoreRepository 
    {
        /// <summary>
        /// Gets all stores.
        /// </summary>
        /// <returns>Get All Stores</returns>
        IEnumerable<StoreEntity> GetAllStores();
    }
}
