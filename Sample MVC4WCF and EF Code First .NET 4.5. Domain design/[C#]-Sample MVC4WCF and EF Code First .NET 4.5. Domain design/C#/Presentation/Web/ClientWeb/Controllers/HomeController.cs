#region File Attributes

// AdminWeb  Project: ClientWeb
// File:  HomeController.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace ClientWeb.Controllers {
    #region

    using System.Web.Mvc;

    using AttributeRouting.Web.Mvc;

    #endregion

    public class HomeController : Controller {

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        [GET("why-us")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Design()
        {
            return View();
        }

    }
}