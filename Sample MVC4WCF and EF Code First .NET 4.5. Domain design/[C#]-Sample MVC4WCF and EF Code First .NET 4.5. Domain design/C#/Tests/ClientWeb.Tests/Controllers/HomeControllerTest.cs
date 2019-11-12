#region File Attributes

// VirtueBuild.System  Project: ClientWeb.Tests
// File:  HomeControllerTest.cs
// Created By: Slava 
// Created On: 2013.05.11 

#endregion

namespace ClientWeb.Tests.Controllers {
    #region

    using System.Web.Mvc;

    using ClientWeb.Controllers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    #endregion

    [TestClass]
    public class HomeControllerTest {

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

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
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}