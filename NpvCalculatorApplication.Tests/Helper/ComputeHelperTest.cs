using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NpvCalculatorApplication.Helper;
using NpvCalculatorApplication.Models;

namespace NpvCalculatorApplication.Tests.Controllers
{
    [TestClass]
    public class ComputeHelperTest
    {
        readonly NpvObjectModel model = new NpvObjectModel()
        {
            IntialInvestment = 150000,
            CashFlows = "50000, 25000",
            LowerBoundDiscountRate = 1.2,
            UpperBoundDiscountRate = 1.4,
            DiscountRateIncrement = 0.1
        };

        [TestMethod]
        public async Task NpvCollection()
        {
            // Arrange
            var helper = new ComputeHelper();

            // Act
            var result = await helper.NpvCollectionAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Labels.Count);
            Assert.AreEqual(3, result.Values.Count);
        }

        [TestMethod]
        public void Npv()
        {
            // Arrange
            var helper = new ComputeHelper();

            // Act
            var result = helper.Npv(model, model.LowerBoundDiscountRate);

            // Assert
            Assert.AreEqual(-76182.26, result);
        }
    }
}
