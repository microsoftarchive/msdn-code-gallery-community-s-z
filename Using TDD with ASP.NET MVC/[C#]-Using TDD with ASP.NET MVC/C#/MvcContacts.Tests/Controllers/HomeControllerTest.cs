using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


using MvcContacts.Models;
using MvcContacts.Controllers;
using MvcContacts.Tests.Models;

namespace MvcContacts.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {

        // <snippet8>
        [TestMethod]
        public void Index_Get_AsksForIndexView() {
            // Arrange
            var controller = GetHomeController(new InMemoryContactRepository());
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        } 
        // </snippet8>

        // <snippet4>
        [TestMethod]
        public void Index_Get_RetrievesAllContactsFromRepository() {
            // Arrange
            Contact contact1 = GetContactNamed(1, "Orlando", "Gee");
            Contact contact2 = GetContactNamed(2, "Keith", "Harris");
            InMemoryContactRepository repository = new InMemoryContactRepository();
            repository.Add(contact1);
            repository.Add(contact2);
            var controller = GetHomeController(repository);

            // Act
            var result = controller.Index();

            // Assert
            var model = (IEnumerable<Contact>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), contact1);
            CollectionAssert.Contains(model.ToList(), contact1);
        } 
        // </snippet4>

        // <snippet9>
        [TestMethod]
        public void Create_Post_PutsValidContactIntoRepository() {
            // Arrange
            InMemoryContactRepository repository = new InMemoryContactRepository();
            HomeController controller = GetHomeController(repository);
            Contact contact = GetContactID_1();

            // Act
            controller.Create(contact);

            // Assert
            IEnumerable<Contact> contacts = repository.GetAllContacts();
            Assert.IsTrue(contacts.Contains(contact));
        } 
        // </snippet9>

        [TestMethod]
        public void Create_Post_ReturnsRedirectOnSuccess() {
            // Arrange
            HomeController controller = GetHomeController(new InMemoryContactRepository());
            Contact model = GetContactID_1();

            // Act
            var result = (RedirectToRouteResult)controller.Create(model);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        // <snippet6>
        [TestMethod]
        public void Create_Post_ReturnsViewIfModelStateIsNotValid() {
            // Arrange
            HomeController controller = GetHomeController(new InMemoryContactRepository());
            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.
            controller.ModelState.AddModelError("", "mock error message");
            Contact model = GetContactNamed(1, "", "");

            // Act
            var result = (ViewResult)controller.Create(model);

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        } 
        // </snippet6>

        // <snippet7>
        [TestMethod]
        public void Create_Post_ReturnsViewIfRepositoryThrowsException() {
            // Arrange
            InMemoryContactRepository repository = new InMemoryContactRepository();
            Exception exception = new Exception();
            repository.ExceptionToThrow = exception;
            HomeController controller = GetHomeController(repository);
            Contact model = GetContactID_1();

            // Act
            var result = (ViewResult)controller.Create(model);

            // Assert
            Assert.AreEqual("Create", result.ViewName);
            ModelState modelState = result.ViewData.ModelState[""];
            Assert.IsNotNull(modelState);
            Assert.IsTrue(modelState.Errors.Any());
            Assert.AreEqual(exception, modelState.Errors[0].Exception);
        } 
        // </snippet7>

        Contact GetContactID_1() {
            return GetContactNamed(1, "Janet", "Gates");
        }

        Contact GetContactNamed(int id, string fName, string lName) {
            return new Contact
            {
                Id = id,
                FirstName = fName,
                LastName = lName,
                Phone = "710-555-0173",
                Email = "janet1@adventure-works.com"
            };

        }

        private static HomeController GetHomeController(IContactRepository repository) {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }



        private class MockHttpContext : HttpContextBase {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User {
                get {
                    return _user;
                }
                set {
                    base.User = value;
                }
            }
        }
    }
}
