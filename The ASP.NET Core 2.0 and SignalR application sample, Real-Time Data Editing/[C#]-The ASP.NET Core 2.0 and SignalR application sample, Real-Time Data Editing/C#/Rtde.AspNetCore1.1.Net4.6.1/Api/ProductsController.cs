using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RealTimeDataEditor.DataAccess;

namespace RealTimeDataEditor.Api
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository productsRepository = new ProductsRepository();

        public string Get()
        {
            //Context.Response.ContentType = "application/json";

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(productsRepository.GetAllProducts(), jsonSerializerSettings);
        }
    }
}
