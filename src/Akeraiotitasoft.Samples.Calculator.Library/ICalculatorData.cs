using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator
{
    public interface ICalculatorData
    {
        bool Exit { get; set; }

        int?[] Numbers {get;}

        Operation? Operation { get; set; }
    }
}
