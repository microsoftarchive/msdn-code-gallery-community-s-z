using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterMVC5.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Demo_Registration U)
        {
            if (ModelState.IsValid)
            {
                using (UsersEntities dc = new UsersEntities())
                {
                    dc.Demo_Registration.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return View(U);
        }
	}
}