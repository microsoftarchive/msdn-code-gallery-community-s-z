using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SignalROwinIISApplication;

[assembly: Microsoft.Owin.OwinStartup(typeof(Startup))]

namespace SignalROwinIISApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.MapSignalR();

            var httpConfiguration = new HttpConfiguration();
            
            httpConfiguration.Formatters.Clear();
            httpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());
            
            httpConfiguration.Formatters.JsonFormatter.SerializerSettings = 
                new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}
