#region File Attributes

// AdminWeb  Project: ClientWeb
// File:  RouteConfig.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace ClientWeb {
    #region

    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }

    }
}