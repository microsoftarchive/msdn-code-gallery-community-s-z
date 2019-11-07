using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Routing.Conventions;

namespace CompositeKeySupport.ODataConventions
{
    public class CompositeKeyRoutingConvention : EntityRoutingConvention
    {
        public override string SelectAction(System.Web.Http.OData.Routing.ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, ILookup<string, System.Web.Http.Controllers.HttpActionDescriptor> actionMap)
        {
            var action = base.SelectAction(odataPath, controllerContext, actionMap);
            if (action != null)
            {
                var routeValues = controllerContext.RouteData.Values;
                if (routeValues.ContainsKey(ODataRouteConstants.Key))
                {
                    var keyRaw = routeValues[ODataRouteConstants.Key] as string;
                    IEnumerable<string> compoundKeyPairs = keyRaw.Split(',');
                    if (compoundKeyPairs == null || compoundKeyPairs.Count() == 0)
                    {
                        return action;
                    }

                    foreach (var compoundKeyPair in compoundKeyPairs)
                    {
                        string[] pair = compoundKeyPair.Split('=');
                        if (pair == null || pair.Length != 2)
                        {
                            continue;
                        }
                        var keyName = pair[0].Trim();
                        var keyValue = pair[1].Trim();

                        routeValues.Add(keyName, keyValue);
                    }
                }
            }

            return action;
        }
    }
}