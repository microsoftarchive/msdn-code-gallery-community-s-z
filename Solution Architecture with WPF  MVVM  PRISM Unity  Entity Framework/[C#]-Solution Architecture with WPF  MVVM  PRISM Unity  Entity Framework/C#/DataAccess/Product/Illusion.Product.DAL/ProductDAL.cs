namespace Illusion.Products.DAL
{
    using System.Collections.Generic;
    using System.Data.Objects;
    using System.Linq;
    using Illusion.ProductEDM;
    using Illusion.Products.DALInterface;

    /// <summary>
    /// ProductDAL class 
    /// </summary>
    public class ProductDAL : IProductDAL
    {
        /// <summary>
        /// Gets all product.
        /// </summary>
        /// <returns>Get All Product</returns>
        public List<Product> GetAllProduct()
        {
            using (IllusionProductDBEntities entites = new IllusionProductDBEntities())
            {
                ObjectQuery<Product> products = entites.Products;

                products.MergeOption = MergeOption.NoTracking;

                IQueryable<Product> query = from product in products select product;

                List<Product> result = query.ToList();

                return result;
            }
        }
    }

    /// <summary>
    /// ProductModelDAL class 
    /// </summary>
    public class ProductModelDAL : IProductModelDAL
    {
        /// <summary>
        /// Gets all product model.
        /// </summary>
        /// <returns>Get All ProductModel</returns>
        List<ProductModel> IProductModelDAL.GetAllProductModel()
        {
            using (IllusionProductDBEntities entities = new IllusionProductDBEntities())
            {
                ObjectQuery<ProductModel> productModels = entities.ProductModels;

                productModels.MergeOption = MergeOption.NoTracking;

                IQueryable<ProductModel> query = from productModel in productModels
                                                 select productModel;

                List<ProductModel> result = query.ToList();
                
                return result;
            }
        }
    }

    /// <summary>
    /// ProductAssemblyDAL class 
    /// </summary>
    public class ProductAssemblyDAL : IProductAssemblyDAL
    {
        /// <summary>
        /// Gets all product assembly.
        /// </summary>
        /// <returns>Get All ProductAssembly</returns>
        public List<ProductAssembly> GetAllProductAssembly()
        {
            using (IllusionProductDBEntities entites = new IllusionProductDBEntities())
            {
                ObjectQuery<ProductAssembly> productAssemblies = entites.ProductAssemblies;

                productAssemblies.MergeOption = MergeOption.NoTracking;

                IQueryable<ProductAssembly> query = from assembly in productAssemblies select assembly;

                List<ProductAssembly> result = query.ToList();

                return result;
            }
        }
    }
}
