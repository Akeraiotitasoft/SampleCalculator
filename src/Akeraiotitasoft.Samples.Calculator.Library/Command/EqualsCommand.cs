using Akeraiotitasoft.IOFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class EqualsCommand : IMenuCommand
    {
        private readonly IStandardOutput _standardOutput;
        private readonly IStandardError _standardError;
        public EqualsCommand(
            IStandardOutput standardOutput,
            IStandardError standardError
            )
        {
            _standardOutput = standardOutput ?? throw new ArgumentNullException(nameof(standardOutput), $"{nameof(standardOutput)} cannot be null");
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), $"{nameof(standardError)} cannot be null");
        }

        public string MenuText => "equals command";

        public string CommandId => "equals";

        public int MenuOrder => 6;

        public void Execute(ICalculatorData receiver)
        {
            if (receiver.Numbers[0] != null && receiver.Operation != null && receiver.Numbers[1] != null)
            {
                switch (receiver.Operation)
                {
                    case Operation.Add:
                        receiver.Numbers[0] = receiver.Numbers[0] + receiver.Numbers[1];
                        break;
                    case Operation.Subtract:
                        receiver.Numbers[0] = receiver.Numbers[0] - receiver.Numbers[1];
                        break;
                    case Operation.Multiply:
                        receiver.Numbers[0] = receiver.Numbers[0] * receiver.Numbers[1];
                        break;
                    case Operation.Divide:
                        receiver.Numbers[0] = receiver.Numbers[0] / receiver.Numbers[1];
                        break;
                    default:
                        _standardError.WriteLine("Calculator is in an invalid state");
                        break;
                }
                receiver.Operation = null;
                receiver.Numbers[1] = null;
                _standardOutput.WriteLine($"result = {receiver.Numbers[0]}");
            }
            else
            {
                _standardError.WriteLine("Calculator is in an invalid state");
            }
        }
    }
}
