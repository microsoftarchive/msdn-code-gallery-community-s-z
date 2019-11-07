namespace HelloWorkflowAndMVC.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;

    using HelloWorkflowAndMVC.Models;

    public class AccountController : Controller
    {
        #region Public Properties

        public IFormsAuthenticationService FormsService { get; set; }

        public IMembershipService MembershipService { get; set; }

        #endregion

        #region Public Methods and Operators

        [Authorize]
        public ActionResult ChangePassword()
        {
            this.ViewBag.PasswordLength = this.MembershipService.MinPasswordLength;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.MembershipService.ChangePassword(this.User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return this.RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    this.ModelState.AddModelError(
                        "", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ViewBag.PasswordLength = this.MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return this.View();
        }

        public ActionResult LogOff()
        {
            this.FormsService.SignOut();

            return this.RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                if (this.MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    this.FormsService.SignIn(model.UserName, model.RememberMe);
                    if (this.Url.IsLocalUrl(returnUrl))
                    {
                        return this.Redirect(returnUrl);
                    }
                    else
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            this.ViewBag.PasswordLength = this.MembershipService.MinPasswordLength;
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                // Attempt to register the user
                var createStatus = this.MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    this.FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            this.ViewBag.PasswordLength = this.MembershipService.MinPasswordLength;
            return View(model);
        }

        #endregion

        #region Methods

        protected override void Initialize(RequestContext requestContext)
        {
            if (this.FormsService == null)
            {
                this.FormsService = new FormsAuthenticationService();
            }
            if (this.MembershipService == null)
            {
                this.MembershipService = new AccountMembershipService();
            }

            base.Initialize(requestContext);
        }

        #endregion

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************
    }
}