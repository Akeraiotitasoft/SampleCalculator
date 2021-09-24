using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class QuitCommand : IMenuCommand
    {
        public QuitCommand()
        {
        }

        public string MenuText => "quit program";

        public string CommandId => "quit";

        public int MenuOrder => 7;

        public void Execute(ICalculatorData receiver)
        {
            receiver.Exit = true;
        }
    }
}
