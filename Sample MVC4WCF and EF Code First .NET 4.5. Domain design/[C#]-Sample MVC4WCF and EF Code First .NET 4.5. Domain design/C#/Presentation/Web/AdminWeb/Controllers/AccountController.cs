#region File Attributes

// VirtueBuild.System  Project: ClientWeb
// File:  AccountController.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion
 #region

    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    using VirtueBuild.Core.Interfaces.Services;
    using VirtueBuild.Core.Services;
    using VirtueBuild.Domain.Members;

    #endregion

namespace AdminWeb.Controllers {
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading;

    using BaseSystem;

    using Models;

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

                        var userRoleId = user.DefaultRoleId.ToString();
                        if (userRoleId.Equals(Constants.CustomerRoleId)) {
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
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.DefaultRoleId.ToString(CultureInfo.InvariantCulture)));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var claimIdentity = new ClaimsIdentity(claims, "Forms");
            Thread.CurrentPrincipal = new ClaimsPrincipal(claimIdentity);
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
                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;

                throw new NotImplementedException("Implement in Security Service");

                //if (changePasswordSucceeded) {
                //    return RedirectToAction("ChangePasswordSuccess");
                //}
                //else {
                //    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                //}
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