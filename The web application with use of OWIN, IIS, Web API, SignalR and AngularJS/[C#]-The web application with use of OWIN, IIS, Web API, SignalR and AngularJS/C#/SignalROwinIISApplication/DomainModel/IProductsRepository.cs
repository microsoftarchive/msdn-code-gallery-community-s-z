using System.Collections.Generic;

namespace SignalROwinIISApplication.DomainModel
{
    public interface IProductsRepository
    {
        IList<Product> GetAllProducts();

        void Insert(Product product);

        void Update(Product product);

        void Delete(int productId);
    }
}