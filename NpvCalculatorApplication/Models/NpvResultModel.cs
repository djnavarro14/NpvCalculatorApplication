using System.Collections.Generic;

namespace NpvCalculatorApplication.Models
{
    public class NpvResultModel
    {
        public List<string> Labels { get; set; } = new List<string>();

        public List<double> Values { get; set; } = new List<double>();
    }
}