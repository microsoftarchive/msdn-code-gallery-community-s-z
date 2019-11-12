using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
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

        public Task AddProduct(Product product)
        {
            productsRepository.Insert(product);

            return Clients.All.InvokeAsync("ProductAdded", product);
        }

        public Task UpdateProduct(Product product)
        {
            productsRepository.Update(product);

            return Clients
                .All/*Except(new[] {Context.ConnectionId})*/
                .InvokeAsync("ProductUpdated", product);
        }

        public Task RemoveProduct(int productId)
        { 
            productsRepository.Delete(productId);
            return Clients.All.InvokeAsync("ProductRemoved", productId);
        }
    }
}