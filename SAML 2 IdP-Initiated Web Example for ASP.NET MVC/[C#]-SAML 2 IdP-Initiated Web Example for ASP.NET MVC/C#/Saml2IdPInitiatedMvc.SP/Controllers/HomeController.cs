using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saml2IdPInitiatedMvc.SP.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to SAML SSO Idp-Initiated SP Example for ASP.NET MVC!";

            return View();
        }
    }
}
