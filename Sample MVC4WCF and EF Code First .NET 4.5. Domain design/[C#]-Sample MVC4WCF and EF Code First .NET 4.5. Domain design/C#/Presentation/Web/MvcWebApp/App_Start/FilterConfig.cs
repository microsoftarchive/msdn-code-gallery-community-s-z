#region File Attributes

// VirtueBuild.System  Project: AdminWeb
// File:  FilterConfig.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace MvcWebApp {
    #region

    using System.Web.Mvc;

    #endregion

    public class FilterConfig {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

    }
}