#region File Attributes

// VirtueBuild.System  Project: AdminWeb
// File:  RouteConfig.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace MvcWebApp {
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