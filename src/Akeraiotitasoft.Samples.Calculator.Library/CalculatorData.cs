using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator
{
    public class CalculatorData : ICalculatorData
    {
        public bool Exit { get; set; }

        public int?[] Numbers { get; } = new int?[2];

        public Operation? Operation { get; set; }
    }
}
