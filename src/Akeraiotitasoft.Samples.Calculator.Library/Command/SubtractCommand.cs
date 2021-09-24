using Akeraiotitasoft.IOFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class SubtractCommand : IMenuCommand
    {
        private readonly IStandardError _standardError;
        public SubtractCommand(
            IStandardError standardError
            )
        {
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), $"{nameof(standardError)} cannot be null");
        }

        public string MenuText => "subtract command";

        public string CommandId => "subtract";

        public int MenuOrder => 3;

        public void Execute(ICalculatorData receiver)
        {
            if (receiver.Numbers[0] != null && receiver.Operation == null && receiver.Numbers[1] == null)
            {
                receiver.Operation = Operation.Subtract;
            }
            else
            {
                _standardError.WriteLine("Calculator is in an invalid state");
            }
        }
    }
}
