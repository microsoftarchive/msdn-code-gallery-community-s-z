using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

using Infragistics.Web.Mvc;

namespace IgniteUI.Controllers
{
    public class GridController : Controller
    {
        private IgniteUI.Models.TrialsDBEntities db = new IgniteUI.Models.TrialsDBEntities();

        public ActionResult View()
        {
            var model = db.Products.AsQueryable();
            return View(model);
        }
    }
}