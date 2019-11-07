using System.Collections.Generic;
using RealTimeDataEditor.Core;

namespace RealTimeDataEditor.DataAccess
{
    public interface IProductsRepository
    {
        IList<Product> GetAllProducts();

        void Insert(Product product);

        void Update(Product product);

        void Delete(int productId);
    }
}