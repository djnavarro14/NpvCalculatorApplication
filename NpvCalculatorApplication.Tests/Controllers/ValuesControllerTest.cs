using Microsoft.VisualStudio.TestTools.UnitTesting;
using NpvCalculatorApplication.Controllers;
using NpvCalculatorApplication.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace NpvCalculatorApplication.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public async Task Post()
        {
            // Arrange
            var controller = new ValuesController();            

            // Act
            dynamic result = await controller.Post(new NpvObjectModel()
            {
                IntialInvestment = 150000,
                CashFlows = "50000, 25000",
                LowerBoundDiscountRate = 1.2,
                UpperBoundDiscountRate = 1.4,
                DiscountRateIncrement = 0.1
            });

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is IHttpActionResult);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(3, result.Content.Labels.Count);
            Assert.AreEqual(3, result.Content.Values.Count);
        }
    }
}
