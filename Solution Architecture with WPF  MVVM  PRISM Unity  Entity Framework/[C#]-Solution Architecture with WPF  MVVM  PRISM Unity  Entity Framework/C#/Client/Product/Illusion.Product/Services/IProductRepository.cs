namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// Product Repository interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>Ge tAll Products</returns>
        IEnumerable<ProductEntity> GetAllProducts();
    }
}
