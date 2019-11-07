#region File Attributes

// VirtueBuild.System  Project: AdminWeb
// File:  HomeController.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace AdminWeb.Controllers {
    #region

    using System.Web.Mvc;

    using BaseSystem;

    #endregion

    [Authorize]
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}