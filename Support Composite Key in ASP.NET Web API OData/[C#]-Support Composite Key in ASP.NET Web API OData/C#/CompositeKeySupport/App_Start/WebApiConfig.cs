using CompositeKeySupport.Models;
using CompositeKeySupport.ODataConventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Routing.Conventions;

namespace CompositeKeySupport
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableQuerySupport();

            var mb = new ODataConventionModelBuilder(config);
            mb.EntitySet<Person>("People");

            var conventions = ODataRoutingConventions.CreateDefault();
            conventions.Insert(0, new CompositeKeyRoutingConvention());

            config.Routes.MapODataRoute(
                routeName: "OData", 
                routePrefix: null, 
                model: mb.GetEdmModel(), 
                pathHandler: new DefaultODataPathHandler(), 
                routingConventions: conventions);
        }
    }
}
