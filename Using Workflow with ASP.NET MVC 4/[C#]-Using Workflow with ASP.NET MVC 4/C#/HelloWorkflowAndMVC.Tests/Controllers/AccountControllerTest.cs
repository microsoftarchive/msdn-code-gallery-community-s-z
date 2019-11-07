namespace HelloWorkflowAndMVC.Tests.Controllers
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;

    using HelloWorkflowAndMVC.Controllers;
    using HelloWorkflowAndMVC.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountControllerTest
    {
        #region Public Methods and Operators

        [TestMethod]
        public void ChangePasswordSuccess_ReturnsView()
        {
            // Arrange
            var controller = GetAccountController();

            // Act
            var result = controller.ChangePasswordSuccess();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ChangePassword_Get_ReturnsView()
        {
            // Arrange
            var controller = GetAccountController();

            // Act
            var result = controller.ChangePassword();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsRedirectOnSuccess()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new ChangePasswordModel
                {
                    OldPassword = "goodOldPassword",
                    NewPassword = "goodNewPassword",
                    ConfirmPassword = "goodNewPassword"
                };

            // Act
            var result = controller.ChangePassword(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsViewIfChangePasswordFails()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new ChangePasswordModel
                { OldPassword = "goodOldPassword", NewPassword = "badNewPassword", ConfirmPassword = "badNewPassword" };

            // Act
            var result = controller.ChangePassword(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(
                "The current password is incorrect or the new password is invalid.",
                controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new ChangePasswordModel
                {
                    OldPassword = "goodOldPassword",
                    NewPassword = "goodNewPassword",
                    ConfirmPassword = "goodNewPassword"
                };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            var result = controller.ChangePassword(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void LogOff_LogsOutAndRedirects()
        {
            // Arrange
            var controller = GetAccountController();

            // Act
            var result = controller.LogOff();

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
        }

        [TestMethod]
        public void LogOn_Get_ReturnsView()
        {
            // Arrange
            var controller = GetAccountController();

            // Act
            var result = controller.LogOn();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithLocalReturnUrl()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new LogOnModel { UserName = "someUser", Password = "goodPassword", RememberMe = false };

            // Act
            var result = controller.LogOn(model, "/someUrl");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            var redirectResult = (RedirectResult)result;
            Assert.AreEqual("/someUrl", redirectResult.Url);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new LogOnModel { UserName = "someUser", Password = "goodPassword", RememberMe = false };

            // Act
            var result = controller.LogOn(model, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsRedirectToHomeOnSuccess_WithExternalReturnUrl()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new LogOnModel { UserName = "someUser", Password = "goodPassword", RememberMe = false };

            // Act
            var result = controller.LogOn(model, "http://malicious.example.net");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new LogOnModel { UserName = "someUser", Password = "goodPassword", RememberMe = false };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            var result = controller.LogOn(model, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsViewIfValidateUserFails()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new LogOnModel { UserName = "someUser", Password = "badPassword", RememberMe = false };

            // Act
            var result = controller.LogOn(model, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(
                "The user name or password provided is incorrect.", controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Register_Get_ReturnsView()
        {
            // Arrange
            var controller = GetAccountController();

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsRedirectOnSuccess()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new RegisterModel
                {
                    UserName = "someUser",
                    Email = "goodEmail",
                    Password = "goodPassword",
                    ConfirmPassword = "goodPassword"
                };

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new RegisterModel
                {
                    UserName = "someUser",
                    Email = "goodEmail",
                    Password = "goodPassword",
                    ConfirmPassword = "goodPassword"
                };
            controller.ModelState.AddModelError("", "Dummy error message.");

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsViewIfRegistrationFails()
        {
            // Arrange
            var controller = GetAccountController();
            var model = new RegisterModel
                {
                    UserName = "duplicateUser",
                    Email = "goodEmail",
                    Password = "goodPassword",
                    ConfirmPassword = "goodPassword"
                };

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(
                "Username already exists. Please enter a different user name.",
                controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        #endregion

        #region Methods

        private static AccountController GetAccountController()
        {
            var requestContext = new RequestContext(new MockHttpContext(), new RouteData());
            var controller = new AccountController
                {
                    FormsService = new MockFormsAuthenticationService(),
                    MembershipService = new MockMembershipService(),
                    Url = new UrlHelper(requestContext),
                };
            controller.ControllerContext = new ControllerContext
                { Controller = controller, RequestContext = requestContext };
            return controller;
        }

        #endregion

        private class MockFormsAuthenticationService : IFormsAuthenticationService
        {
            #region Constants and Fields

            public bool SignIn_WasCalled;

            public bool SignOut_WasCalled;

            #endregion

            #region Public Methods and Operators

            public void SignIn(string userName, bool createPersistentCookie)
            {
                // verify that the arguments are what we expected
                Assert.AreEqual("someUser", userName);
                Assert.IsFalse(createPersistentCookie);

                this.SignIn_WasCalled = true;
            }

            public void SignOut()
            {
                this.SignOut_WasCalled = true;
            }

            #endregion
        }

        private class MockHttpContext : HttpContextBase
        {
            #region Constants and Fields

            private readonly HttpRequestBase _request = new MockHttpRequest();

            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

            #endregion

            #region Public Properties

            public override HttpRequestBase Request
            {
                get
                {
                    return this._request;
                }
            }

            public override IPrincipal User
            {
                get
                {
                    return this._user;
                }
                set
                {
                    base.User = value;
                }
            }

            #endregion
        }

        private class MockHttpRequest : HttpRequestBase
        {
            #region Constants and Fields

            private readonly Uri _url = new Uri("http://mysite.example.com/");

            #endregion

            #region Public Properties

            public override Uri Url
            {
                get
                {
                    return this._url;
                }
            }

            #endregion
        }

        private class MockMembershipService : IMembershipService
        {
            #region Public Properties

            public int MinPasswordLength
            {
                get
                {
                    return 10;
                }
            }

            #endregion

            #region Public Methods and Operators

            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email)
            {
                if (userName == "duplicateUser")
                {
                    return MembershipCreateStatus.DuplicateUserName;
                }

                // verify that values are what we expected
                Assert.AreEqual("goodPassword", password);
                Assert.AreEqual("goodEmail", email);

                return MembershipCreateStatus.Success;
            }

            public bool ValidateUser(string userName, string password)
            {
                return (userName == "someUser" && password == "goodPassword");
            }

            #endregion
        }
    }
}