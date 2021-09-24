using Akeraiotitasoft.IOFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class AddCommand : IMenuCommand
    {
        private readonly IStandardError _standardError;
        public AddCommand(
            IStandardError standardError
            )
        {
            _standardError = standardError ?? throw new ArgumentNullException(nameof(standardError), $"{nameof(standardError)} cannot be null");
        }

        public string MenuText => "add command";

        public string CommandId => "add";

        public int MenuOrder => 2;

        public void Execute(ICalculatorData receiver)
        {
            if (receiver.Numbers[0] != null && receiver.Operation == null && receiver.Numbers[1] == null)
            {
                receiver.Operation = Operation.Add;
            }
            else
            {
                _standardError.WriteLine("Calculator is in an invalid state");
            }
        }
    }
}
