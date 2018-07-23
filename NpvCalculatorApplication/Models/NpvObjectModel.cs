using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NpvCalculatorApplication.Models
{
    public class NpvObjectModel
    {
        [Display(Name = "Initial Investment ($):")]
        public double IntialInvestment { get; set; }

        public string CashFlows { get; set; }

        [Display(Name = "Lower Bound Discount Rate (%):")]
        public double LowerBoundDiscountRate { get; set; } = 1;

        [Display(Name = "Upper Bound Discount Rate (%):")]
        public double UpperBoundDiscountRate { get; set; } = 5;

        [Display(Name = "Discount Rate Increment (%):")]
        public double DiscountRateIncrement { get; set; } = 0.25;

        public List<double> GetCashFlows()
        {
            var cashFlows = CashFlows.Split(',').Select(Double.Parse).ToList();
            cashFlows.Insert(0, -IntialInvestment);
            return cashFlows;
        }
    }
}