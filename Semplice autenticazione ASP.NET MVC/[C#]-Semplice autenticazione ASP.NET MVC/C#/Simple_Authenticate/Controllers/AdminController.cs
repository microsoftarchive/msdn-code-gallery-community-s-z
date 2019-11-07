using Simple_Authenticate.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Simple_Authenticate.Controllers
{
    public class AdminController : Controller
    {


        // GET: /Admin/index
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Admin/login
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (this.ModelState.IsValid && FormsAuthentication.Authenticate(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "admin");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Incorrect username or password.");
            return View(model);
        }

        // GET: /Admin/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }



    }
}