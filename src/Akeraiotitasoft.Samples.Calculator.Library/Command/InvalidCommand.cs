using Akeraiotitasoft.Command.Abstractions;
using Akeraiotitasoft.IOFacade;
using Akeraiotitasoft.Samples.Calculator.Library.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Command
{
    public class InvalidCommand : IMenuCommand
    {
        private readonly IStandardOutput _standardOutput;

        public InvalidCommand(IStandardOutput standardOutput)
        {
            _standardOutput = standardOutput ?? throw new ArgumentNullException(nameof(standardOutput), $"{nameof(standardOutput)} cannot be null");
        }

        public string CommandId => "invalid";

        public string MenuText => throw new InvalidOperationException("Do not show this command on the manu.  It is invalid!");

        public int MenuOrder => 0;

        public void Execute(ICalculatorData receiver)
        {
            _standardOutput.WriteLine("Invalid Command");
        }
    }
}
