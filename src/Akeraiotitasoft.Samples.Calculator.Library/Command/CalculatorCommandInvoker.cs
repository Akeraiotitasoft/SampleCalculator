using Akeraiotitasoft.Command;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class CalculatorCommandInvoker : CommandInvoker<ICalculatorData, string>
    {
        public CalculatorCommandInvoker(IEnumerable<IMenuCommand> menuCommands, ILogger<CalculatorCommandInvoker> logger)
            : base(menuCommands, logger)
        {
        }

        protected override string InvalidCommandId => "invalid";
    }
}
