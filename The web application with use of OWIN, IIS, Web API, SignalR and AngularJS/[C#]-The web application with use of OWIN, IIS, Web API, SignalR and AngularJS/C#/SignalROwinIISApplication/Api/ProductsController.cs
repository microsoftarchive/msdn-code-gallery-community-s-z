using System.Collections.Generic;
using System.Web.Http;
using SignalROwinIISApplication.DomainModel;

namespace SignalROwinIISApplication.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductsRepository productsRepository = new ProductsRepository();

        public IEnumerable<Product> Get()
        {
            return this.productsRepository.GetAllProducts();
        }
    }
}
