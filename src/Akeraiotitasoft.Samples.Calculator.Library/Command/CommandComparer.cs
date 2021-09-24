using Akeraiotitasoft.Command.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.Command
{
    public class CommandComparer : IComparer<ICommand<ICalculatorData, string>>
    {
        public CommandComparer()
        {
        }

        public int Compare(ICommand<ICalculatorData, string> x, ICommand<ICalculatorData, string> y)
        {
            IMenuCommand xMenuCommand = x as IMenuCommand;
            IMenuCommand yMenuCommand = y as IMenuCommand;
            if (xMenuCommand != null && yMenuCommand != null)
            {
                return xMenuCommand.MenuOrder.CompareTo(yMenuCommand.MenuOrder);
            }
            else if (xMenuCommand != null && yMenuCommand == null)
            {
                return -1;
            }
            else if (xMenuCommand == null && yMenuCommand != null)
            {
                return 1;
            }
            else
            {
                return x.CommandId.CompareTo(y.CommandId);
            }
        }
    }
}
