using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Web;
using TDD.Web.Controllers;
using TDD.ServicesLayer;
using Moq;
namespace TDD.Web.Tests.Controllers
{
    [TestClass]
    public class StudentControllerMoqTest
    {
        private Mock<IStudentRepository> _mockStudentService;
       // private Mock<IAjaxGridFactory> _mockAjaxGridFactory;
        private StudentController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockStudentService = new Mock<IStudentRepository>();
            //_mockAjaxGridFactory = new Mock<IAjaxGridFactory>();
            _controller = new StudentController(_mockStudentService.Object);
        }
        [TestMethod]
        public void Index()
        {
            // Arrange
            StudentController controller = new StudentController(_mockStudentService.Object);

            // Act
            //ViewResult result = controller.Index("name_desc", "", "", 1) as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            ViewResult result = controller.Index("name_desc", "", "", 1) as ViewResult;

           
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            StudentController controller = new StudentController(_mockStudentService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            StudentController controller = new StudentController(_mockStudentService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
