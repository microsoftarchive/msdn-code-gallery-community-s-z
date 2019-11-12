using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saml2IdpInitiatedMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to SAML SSO Idp-Initiated IdP Example for ASP.NET MVC!";

            string serviceProviderUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["ServiceProviderUrl"];
            ViewData["NavigateUrl"] = System.Web.VirtualPathUtility.ToAbsolute(string.Format("~/Service?spUrl={0}", HttpUtility.UrlEncode(serviceProviderUrl)));

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
