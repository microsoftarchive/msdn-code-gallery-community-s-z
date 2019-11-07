namespace Illusion.Products.BL
{
    using System.Collections.Generic;
    using Illusion.ProductEDM;
    using Illusion.Products.BLInterface;
    using Illusion.Products.DAL;
    using Illusion.Products.DALInterface;

    /// <summary>
    /// Product BL
    /// </summary>
    public class ProductBL : IProductBL
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>Get All Products</returns>
        public List<Product> GetAllProducts()
        {
            IProductDAL productDAL = new ProductDAL();
            List<Product> result = productDAL.GetAllProduct();
            return result;
        }
    }

    /// <summary>
    /// ProductModel BL
    /// </summary>
    public class ProductModelBL : IProductModelBL
    {
        /// <summary>
        /// Gets all product model.
        /// </summary>
        /// <returns>Get All ProductModel</returns>
        public List<ProductModel> GetAllProductModel()
        {
            IProductModelDAL productModelDAL = new ProductModelDAL();
            List<ProductModel> result = productModelDAL.GetAllProductModel();
            return result;
        }
    }

    /// <summary>
    /// ProductAssembly BL
    /// </summary>
    public class ProductAssemblyBL : IProductAssemblyBL
    {
        /// <summary>
        /// Gets all product assembly.
        /// </summary>
        /// <returns>Get All ProductAssembly</returns>
        public List<ProductAssembly> GetAllProductAssembly()
        {
            IProductAssemblyDAL productAssemblyDAL = new ProductAssemblyDAL();
            List<ProductAssembly> result = productAssemblyDAL.GetAllProductAssembly();
            return result;
        }
    }

}
