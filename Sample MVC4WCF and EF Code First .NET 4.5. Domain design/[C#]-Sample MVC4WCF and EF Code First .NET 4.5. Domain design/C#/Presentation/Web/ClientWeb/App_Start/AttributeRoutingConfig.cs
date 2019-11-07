#region File Attributes

// AdminWeb  Project: ClientWeb
// File:  AttributeRoutingConfig.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

using ClientWeb;

using WebActivator;

#endregion

[assembly: PreApplicationStartMethod(typeof (AttributeRoutingConfig), "Start")]

namespace ClientWeb {
    #region

    using System.Web.Routing;

    using AttributeRouting.Web.Mvc;

    #endregion

    public static class AttributeRoutingConfig {

        public static void RegisterRoutes(RouteCollection routes)
        {
            // See http://github.com/mccalltd/AttributeRouting/wiki for more options.
            // To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            routes.MapAttributeRoutes();
        }

        public static void Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

    }
}