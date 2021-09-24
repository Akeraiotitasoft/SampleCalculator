using Akeraiotitasoft.Command.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public interface IMenuCommand : ICommand<ICalculatorData, string>
    {
        int MenuOrder { get; }
        
        string MenuText { get; }
    }
}
