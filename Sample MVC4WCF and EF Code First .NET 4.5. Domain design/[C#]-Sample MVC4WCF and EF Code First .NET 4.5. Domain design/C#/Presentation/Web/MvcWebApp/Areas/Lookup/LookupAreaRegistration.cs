#region File Attributes

// Tateeda.OpenFramework  Project: MvcWebApp
// File:  LookupAreaRegistration.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace MvcWebApp.Areas.Lookup {
    #region

    using System.Web.Mvc;

    #endregion

    public class LookupAreaRegistration : AreaRegistration {

        public override string AreaName { get { return "Lookup"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Lookup_default",
                "Lookup/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
                );
        }

    }
}