using Akeraiotitasoft.IOFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class InputCommand : IMenuCommand
    {
        private readonly IStandardInput _standardInput;
        private readonly IStandardError _standardError;
        public InputCommand(
            IStandardInput standardInput,
            IStandardError standardError
            )
        {
            _standardInput = standardInput ?? throw new ArgumentNullException(nameof(standardInput), $"{nameof(standardInput)} cannot be null");
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), $"{nameof(standardError)} cannot be null");
        }

        public string MenuText => "input a number";

        public string CommandId => "input";

        public int MenuOrder => 1;

        public void Execute(ICalculatorData receiver)
        {
            if (receiver.Numbers.Length == 2)
            {
                string input = _standardInput.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    if (receiver.Numbers[0] == null && receiver.Operation == null && receiver.Numbers[1] == null)
                    {
                        receiver.Numbers[0] = value;
                    }
                    else if (receiver.Numbers[0] != null && receiver.Operation != null && receiver.Numbers[1] == null)
                    {
                        receiver.Numbers[1] = value;
                    }
                    else
                    {
                        _standardError.WriteLine("Calculator is in an invalid state.");
                    }
                }
                else
                {
                    _standardError.WriteLine("Invalid input.  An integer is expected.");
                }
            }
        }
    }
}
