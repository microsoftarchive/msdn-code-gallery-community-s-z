namespace HelloWorkflowAndMVC.Tests.Controllers
{
    using System.Web.Mvc;

    using HelloWorkflowAndMVC.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelloControllerTest
    {
        #region Public Properties

        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods and Operators

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HelloController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Hello MVC from Workflow", result.ViewBag.Greeting);
        }

        #endregion
    }
}