using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsyncActions.Models;
namespace AsyncActions.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Test t = new Test();
            var myList= t.GetData();
            return View(myList);
        }

    }
}
