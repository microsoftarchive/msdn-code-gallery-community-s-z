#region File Attributes

// AdminWeb  Project: ClientWeb
// File:  FilterConfig.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace ClientWeb {
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