#region File Attributes

// VirtueBuild.System  Project: AdminWeb
// File:  WebApiConfig.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace MvcWebApp {
    #region

    using System.Web.Http;

    #endregion

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }

    }
}