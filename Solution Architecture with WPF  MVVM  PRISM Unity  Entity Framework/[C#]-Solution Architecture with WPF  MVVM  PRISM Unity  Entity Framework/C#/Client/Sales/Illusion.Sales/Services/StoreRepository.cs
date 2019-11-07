namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.Sales.BL;
    using Illusion.Sales.BLInterface;
    using Illusion.Sales.EDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// Store Repository class
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        /// <summary>
        /// Gets all stores.
        /// </summary>
        /// <returns>
        /// Get All Stores
        /// </returns>
        public IEnumerable<StoreEntity> GetAllStores()
        {
            IStoreBL storeBL = new StoreBL();
            List<StoreEntity> result = new List<StoreEntity>();
            foreach (Store source in storeBL.GetAllStore())
            {
                StoreEntity target = new StoreEntity();
                target.StoreID = source.StoreID;
                target.Name = source.Name;
                target.SalesOrderNumber = source.SalesOrderNumber;
                target.OrderDate = source.OrderDate;
                target.TotalDue = source.TotalDue;
                result.Add(target);
            }
            return result;
        }
    }
}
