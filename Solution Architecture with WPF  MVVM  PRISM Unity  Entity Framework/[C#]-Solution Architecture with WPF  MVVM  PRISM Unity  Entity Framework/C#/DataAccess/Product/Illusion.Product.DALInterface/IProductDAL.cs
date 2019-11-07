namespace Illusion.Products.DALInterface
{
    using System.Collections.Generic;
    using Illusion.ProductEDM;

    /// <summary>
    /// ProductDAL interface
    /// </summary>
    public interface IProductDAL
    {
        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns>Get All Product</returns>
        List<Product> GetAllProduct();
    }

    /// <summary>
    /// ProductModelDAL class
    /// </summary>
    public interface IProductModelDAL
    {
        /// <summary>
        /// Gets all product model.
        /// </summary>
        /// <returns>Get All ProductModel</returns>
        List<ProductModel> GetAllProductModel();
    }

    /// <summary>
    /// ProductAssemblyDAL interface
    /// </summary>
    public interface IProductAssemblyDAL
    {
        /// <summary>
        /// Gets all product assembly.
        /// </summary>
        /// <returns>Get All ProductAssembly</returns>
        List<ProductAssembly> GetAllProductAssembly();
    }
}
