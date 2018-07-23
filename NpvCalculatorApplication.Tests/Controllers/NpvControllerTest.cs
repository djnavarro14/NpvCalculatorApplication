using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NpvCalculatorApplication.Controllers;

namespace NpvCalculatorApplication.Tests.Controllers
{
    [TestClass]
    public class NpvControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new NpvController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
