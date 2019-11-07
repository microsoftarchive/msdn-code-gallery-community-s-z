namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductAssembl yRepository interface
    /// </summary>
    public interface IProductAssemblyRepository
    {
        /// <summary>
        /// Gets all product assemblys.
        /// </summary>
        /// <returns>Get All ProductAssemblies</returns>
        IEnumerable<ProductAssemblyEntity> GetAllProductAssemblylies();
    }
}
