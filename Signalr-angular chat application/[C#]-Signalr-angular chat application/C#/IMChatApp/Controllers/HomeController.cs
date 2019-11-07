using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMChatApp.Models;

namespace IMChatApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Chat(Login model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Home Page";
                ViewBag.Username = model.UserNick;
                return View();
            }
            return View("Index");
        }
    }
}
