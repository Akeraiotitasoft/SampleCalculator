using Akeraiotitasoft.IOFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class DivideCommand : IMenuCommand
    {
        private readonly IStandardError _standardError;
        public DivideCommand(
            IStandardError standardError
            )
        {
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), $"{nameof(standardError)} cannot be null");
        }

        public string MenuText => "divide command";

        public string CommandId => "divide";

        public int MenuOrder => 5;

        public void Execute(ICalculatorData receiver)
        {
            if (receiver.Numbers[0] != null && receiver.Operation == null && receiver.Numbers[1] == null)
            {
                receiver.Operation = Operation.Divide;
            }
            else
            {
                _standardError.WriteLine("Calculator is in an invalid state");
            }
        }
    }
}
