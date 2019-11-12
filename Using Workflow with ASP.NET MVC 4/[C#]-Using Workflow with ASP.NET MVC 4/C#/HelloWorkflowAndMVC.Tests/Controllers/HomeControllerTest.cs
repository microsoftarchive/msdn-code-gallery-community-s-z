namespace HelloWorkflowAndMVC.Tests.Controllers
{
    using System.Web.Mvc;

    using HelloWorkflowAndMVC.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HomeControllerTest
    {
        #region Public Methods and Operators

        [TestMethod]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Welcome to Workflow and ASP.NET MVC!", result.ViewBag.Message);
        }

        #endregion
    }
}