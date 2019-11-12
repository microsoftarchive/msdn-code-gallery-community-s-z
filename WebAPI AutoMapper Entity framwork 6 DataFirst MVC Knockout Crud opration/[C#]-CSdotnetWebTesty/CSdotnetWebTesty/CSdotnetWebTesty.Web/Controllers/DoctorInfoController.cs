using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSdotnetWebTesty.Web.Controllers
{
    public class DoctorInfoController : Controller
    {
        //
        // GET: /DoctorInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }

    }
}
