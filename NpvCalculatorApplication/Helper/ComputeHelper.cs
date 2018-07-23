using NpvCalculatorApplication.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NpvCalculatorApplication.Helper
{
    public class ComputeHelper
    {
        public async Task<NpvResultModel> NpvCollectionAsync(NpvObjectModel model)
        {
            var result = new NpvResultModel();
            await Task.Run(() =>
            {
                var cashFlows = model.CashFlows.Split(',').Select(Double.Parse).ToList();
                cashFlows.Insert(0, -model.IntialInvestment);

                var discountRate = model.LowerBoundDiscountRate;
                while (discountRate <= model.UpperBoundDiscountRate)
                {
                    result.Labels.Add($"{discountRate}%");
                    result.Values.Add(Npv(model, discountRate));

                    discountRate = Math.Round(discountRate + model.DiscountRateIncrement, 2);
                };
            });
            return result;
        }

        public double Npv(NpvObjectModel model, double discountRate)
        {
            var cashFlows = model.GetCashFlows();
            var npv = cashFlows.Select((c, n) => c / Math.Pow(1 + (discountRate / 100), n)).Sum();
            return Math.Round(npv, 2);
        }
    }
}