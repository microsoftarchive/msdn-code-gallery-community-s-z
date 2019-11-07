#region File Attributes

// VirtueBuild.System  Project: ClientWeb
// File:  AccountController.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion
 #region



#endregion

namespace MvcWebApp.Controllers {
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Web.Mvc;
    using System.Web.Security;

    using BaseSystem;

    using Models;

    using VirtueBuild.Core.Interfaces.Services;
    using VirtueBuild.Core.Services;
    using VirtueBuild.Domain.Members;

    using System.Collections.Generic;
    using System.Globalization;
    using System.Security;
    using System.Security.Claims;
    using System.Threading;

    using VirtueBuild.Domain;

    [Authorize]
    public class AccountController : BaseController {

        private readonly WcfServiceInvoker _wcfService;

        public AccountController()
        {
            _wcfService = new WcfServiceInvoker();
        }

        public ActionResult UserProfile()
        {
            return View();
        }
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid) {
                try {
                    var user =
                        _wcfService.InvokeService<IVirtueSecurityService, User>(
                            (svc) => svc.GetUserByUserNameOrEmail(model.UserName, model.UserName));

                    if (user == null) {
                        throw new Exception("Invalid User Name");
                    }

                    var hashedPassword = _wcfService.InvokeService<IVirtueSecurityService, string>(
                        (svc) => svc.CreatePasswordHash(model.Password, user.Salt));

                    if (hashedPassword.Equals(user.Password)) {
                        FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);

                        SetUserIdentity(user);

                        if (!HttpContext.User.IsInRole(Constants.SysAdminRole))
                        {
                            FormsAuthentication.SignOut();
                            throw new SecurityException("Invalid user role. Access denied");
                        }

                        if (Url.IsLocalUrl(returnUrl)) {
                                return Redirect(returnUrl);
                            }
                            else {
                                return RedirectToAction("Index", "Home");
                            }
                        
                    }
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void SetUserIdentity(User user)
        {
            var identity = new GenericIdentity(user.UserName);
            var roles = user.Roles.Select(r => r.Name).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            HttpContext.User = principal;

        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }



        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid) {
                throw new NotImplementedException("Implement in Security Service");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}