namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.Products.BL;
    using Illusion.Products.BLInterface;
    using Illusion.UI.Entities;

    using products = Illusion.ProductEDM;
    /// <summary>
    /// Product Repository class
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Ge tAll Products
        /// </returns>
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            IList<ProductEntity> result = new List<ProductEntity>();
            IProductBL productBL = new ProductBL();
            List<products.Product> productList = productBL.GetAllProducts();
            foreach (products.Product source in productList)
            {
                ProductEntity target = new ProductEntity();
                target.ProductID = source.ProductID;
                target.Category = source.Category;
                target.SubCategory = source.Subcategory;
                target.Model = source.Model;
                target.Product = source.Product1;
                result.Add(target);
            }
            return result;
        }
    }
}
