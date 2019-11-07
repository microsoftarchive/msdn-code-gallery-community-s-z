using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Grid.Mvc.Ajax.GridExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VSMMvcTDD.Controllers;
using VSMMvcTDD.Entities;
using VSMMvcTDD.GridExtensions;
using VSMMvcTDD.Models;
using VSMMvcTDD.Services;

namespace VSMMvcTDD.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IContactService> _mockContactService;
        private Mock<IAjaxGridFactory> _mockAjaxGridFactory;
        private HomeController _controller;
        private const int _partitionSize = 10;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContactService = new Mock<IContactService>();
            _mockAjaxGridFactory = new Mock<IAjaxGridFactory>();
            _controller = new HomeController(_mockContactService.Object, _mockAjaxGridFactory.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockContactService.VerifyAll();
            _mockAjaxGridFactory.VerifyAll();
        }

        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubContacts = (new List<Contact>
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@email.com"
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "janedoe@email.com"
                }
            }).AsQueryable();
            var expectedGridRow = new ContactViewModel()
            {
                Id = stubContacts.ToList()[1].Id,
                Email = stubContacts.ToList()[1].Email,
                FirstName = stubContacts.ToList()[1].FirstName,
                LastName = stubContacts.ToList()[1].LastName
            };
            _mockContactService.Setup(x => x.GetAllContacts()).Returns(stubContacts);
            _mockAjaxGridFactory.Setup(
                x =>
                    x.CreateAjaxGrid(It.Is<IQueryable<ContactViewModel>>(c => c.First() == expectedGridRow), 1,
                        false, _partitionSize));

            var result = _controller.Index() as ViewResult;
        }

        [TestMethod]
        public void Create_ExpectPartialViewResultReturned()
        {
            string expectedView = "_Create";

            var actual = _controller.Create() as PartialViewResult;
            var actualModel = actual.Model as ContactViewModel;

            Assert.IsNotNull(actualModel);
            Assert.AreEqual(expectedView, actual.ViewName);
        }

        [TestMethod]
        public void Create_Given_Valid_Model_ExpectRecordSavedAndJsonSuccessReturned()
        {
            var model = new ContactViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com"
            };
            const int stubId = 1;
            _mockContactService.Setup(x => x.AddContact(It.Is<Contact>(c => c.FirstName == model.FirstName
                                                                            && c.LastName == model.LastName &&
                                                                            c.Email == model.Email))).Returns(stubId);
            const string expected = "{ Success = True, Object = 1 }";
            var actual = _controller.Create(model) as JsonResult;

            Assert.AreEqual(expected, actual.Data.ToString());
        }

        [TestMethod]
        public void Create_Given_InvalidModelState_ExpectPartialResultReturned()
        {
            var model = new ContactViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com"
            };
            _controller.ModelState.AddModelError("", "error");
            string expectedView = "_Create";

            var actual = _controller.Create(model) as PartialViewResult;

            Assert.AreEqual(expectedView, actual.ViewName);
            Assert.AreEqual(model, actual.Model);
        }

        [TestMethod]
        public void Edit_Given_id_ExpectPartialViewResultReturned()
        {
            int id = 1;
            string expectedView = "_Edit";
            var stubContact = new Contact()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@email.com"
            };
            _mockContactService.Setup(x => x.GetContact(id)).Returns(stubContact);
            var expectedVm = new ContactViewModel()
            {
                Id = stubContact.Id,
                FirstName = stubContact.FirstName,
                LastName = stubContact.LastName,
                Email = stubContact.Email
            };

            var actual = _controller.Edit(id) as PartialViewResult;
            var actualVm = actual.Model as ContactViewModel;

            Assert.AreEqual(expectedView, actual.ViewName);
            Assert.AreEqual(expectedVm.Email, actualVm.Email);
            Assert.AreEqual(expectedVm.FirstName, actualVm.FirstName);
            Assert.AreEqual(expectedVm.Id, actualVm.Id);
            Assert.AreEqual(expectedVm.LastName, actualVm.LastName);
        }

        [TestMethod]
        public void Edit_Given_Valid_Model_ExpectModelUpdatedAndJsonSuccessReturned()
        {
            var model = new ContactViewModel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com"
            };
            _mockContactService.Setup(x => x.EditContact(It.Is<Contact>(c => c.Id == model.Id &&
                                                        c.FirstName == model.FirstName
                                                        && c.LastName == model.LastName &&
                                                        c.Email == model.Email)));
            var expected = "{ Success = True }";
            var actual = _controller.Edit(model) as JsonResult;

            Assert.AreEqual(expected, actual.Data.ToString());
        }


        [TestMethod]
        public void Edit_Given_InvalidModelState_ExpectPartialResultReturned()
        {
            var model = new ContactViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com"
            };
            _controller.ModelState.AddModelError("", "error");
            string expectedView = "_Edit";

            var actual = _controller.Edit(model) as PartialViewResult;

            Assert.AreEqual(expectedView, actual.ViewName);
            Assert.AreEqual(model, actual.Model);
        }

        [TestMethod]
        public void Delete_Given_id_ExpectJsonSuccessReturned()
        {
            int id = 1;
            _mockContactService.Setup(x => x.DeleteContact(id));
            const string expected = "{ Success = True }";
            var actual = _controller.Delete(id);

            Assert.AreEqual(expected, actual.Data.ToString());
        }

        [TestMethod]
        public void ContactsGrid_Given_page_and_renderRowsOnly_ExpectJsonResultReturned()
        {
            int? page = 1;
            bool? renderRowsOnly = true;
            var stubContacts = (new List<Contact>
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@email.com"
                },
            }).AsQueryable();
            _mockContactService.Setup(x => x.GetAllContacts()).Returns(stubContacts);
            var expectedGridRow = new ContactViewModel()
            {
                Id = stubContacts.First().Id,
                Email = stubContacts.First().Email,
                FirstName = stubContacts.First().FirstName,
                LastName = stubContacts.First().LastName
            };
             var stubAjaxGrid = new Mock<IAjaxGrid>();
            _mockAjaxGridFactory.Setup(
                x =>
                    x.CreateAjaxGrid(It.Is<IQueryable<ContactViewModel>>(c => c.First() == expectedGridRow), page.Value,
                        true, _partitionSize)).Returns(stubAjaxGrid.Object);
            string stubGridHtml = "grid";
            stubAjaxGrid.Setup(x => x.ToJson("_ContactsGrid", _controller)).Returns(stubGridHtml);
            bool hasItems = true;
            stubAjaxGrid.Setup(x => x.HasItems).Returns(hasItems);
            string expectedData = "{ Html = grid, HasItems = True }";

            var actual = _controller.ContactsGrid(page, renderRowsOnly);

            Assert.AreEqual(expectedData, actual.Data.ToString());
        }
    }
}
