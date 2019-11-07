using Microsoft.AspNet.SignalR;
using RealTimeDataEditor.Core;
using RealTimeDataEditor.DataAccess;

namespace RealTimeDataEditor
{
    public class ProductMessageHub : Hub
    {
        private readonly IProductsRepository productsRepository;

        public ProductMessageHub()
        {
            productsRepository = new ProductsRepository();
        }

        public void AddProduct(Product product)
        {
            productsRepository.Insert(product);

            Clients.All.productAdded(product);
        }

        public void UpdateProduct(Product product)
        {
            productsRepository.Update(product);

            Clients.All.productUpdated(product);
        }

        public void RemoveProduct(int productId)
        {
            productsRepository.Delete(productId);

            Clients.All.productRemoved(productId);
        }
    }
}