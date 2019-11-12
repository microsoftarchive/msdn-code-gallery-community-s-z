namespace Illusion.Product.Services
{
    using System.Collections.Generic;
    using Illusion.ProductEDM;
    using Illusion.Products.BL;
    using Illusion.Products.BLInterface;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductModel Repository class
    /// </summary>
    public class ProductModelRepository : IProductModelRepository
    {
        /// <summary>
        /// Gets all product models.
        /// </summary>
        /// <returns>
        /// Get All ProductModels
        /// </returns>
        public IEnumerable<ProductModelEntity> GetAllProductModels()
        {
            IList<ProductModelEntity> result = new List<ProductModelEntity>();
            IProductModelBL productModelBL = new ProductModelBL();
            List<ProductModel> productModelList = productModelBL.GetAllProductModel();
            foreach (ProductModel source in productModelList)
            {
                ProductModelEntity target = new ProductModelEntity();
                target.ProductModelID = source.ProductModel1;
                target.ProductModel = source.Product_Model;
                target.Culture = source.CultureID;
                target.Language = source.Language;
                result.Add(target);
            }
            return result;
        }
    }
}
