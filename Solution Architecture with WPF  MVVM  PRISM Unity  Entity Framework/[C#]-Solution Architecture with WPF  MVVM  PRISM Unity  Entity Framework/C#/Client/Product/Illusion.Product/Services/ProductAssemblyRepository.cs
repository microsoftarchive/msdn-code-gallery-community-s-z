namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.ProductEDM;
    using Illusion.Products.BL;
    using Illusion.Products.BLInterface;

    using Illusion.UI.Entities;
    /// <summary>
    /// ProductAssembly Repository class
    /// </summary>
    public class ProductAssemblyRepository : IProductAssemblyRepository
    {
        /// <summary>
        /// Gets all product assemblys.
        /// </summary>
        /// <returns>
        /// Get All ProductAssemblies
        /// </returns>
        public IEnumerable<ProductAssemblyEntity> GetAllProductAssemblylies()
        {
            List<ProductAssemblyEntity> result = new List<ProductAssemblyEntity>();
            IProductAssemblyBL productAssemblyBL = new ProductAssemblyBL();
            List<ProductAssembly> productAssemblyList = productAssemblyBL.GetAllProductAssembly();
            foreach (ProductAssembly source in productAssemblyList)
            {
                ProductAssemblyEntity target = new ProductAssemblyEntity();
                target.ProductAssemblyID = source.ProductAssemblyID;
                target.AssemblyID = source.AssemblyID;
                target.ComponentID = source.ComponentID;
                target.Name = source.Name;
                target.PerAssemblyQty = source.PerAssemblyQty;
                target.EndDate = source.EndDate;
                target.ComponentLevel = source.ComponentLevel;
                result.Add(target);
            }
            return result;
        }
    }
}
