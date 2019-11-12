using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Illusion.ProductEDM;

namespace Illusion.Products.BLInterface
{
    /// <summary>
    /// Interface Product BL
    /// </summary>
    public interface IProductBL
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All Products</returns>
        List<Product> GetAllProducts();
    }

    /// <summary>
    /// Interface Product Model BL
    /// </summary>
    public interface IProductModelBL
    {
        /// <summary>
        /// Gets all product model.
        /// </summary>
        /// <returns> All Product Model</returns>
        List<ProductModel> GetAllProductModel();
    }

    /// <summary>
    /// Interface Product Assembly BL
    /// </summary>
    public interface IProductAssemblyBL
    {
        /// <summary>
        /// Gets all product assembly.
        /// </summary>
        /// <returns>All Product Assembly</returns>
        List<ProductAssembly> GetAllProductAssembly();
    }
}
