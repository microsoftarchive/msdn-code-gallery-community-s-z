namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductModel Repository  interface
    /// </summary>
    public interface IProductModelRepository
    {
        /// <summary>
        /// Gets all product models.
        /// </summary>
        /// <returns>Get All ProductModels</returns>
        IEnumerable<ProductModelEntity> GetAllProductModels();
    }
}
