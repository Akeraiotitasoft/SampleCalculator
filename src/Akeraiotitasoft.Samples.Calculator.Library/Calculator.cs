using Akeraiotitasoft.Command.Abstractions;
using Akeraiotitasoft.IOFacade;
using Akeraiotitasoft.Samples.Calculator.Library.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator
{
    /// <summary>
    /// Class Under Test
    /// </summary>
    public class Calculator : ICalculator
    {
        private readonly IStandardInput _standardInput;
        private readonly IStandardOutput _standardOutput;
        private readonly IStandardError _standardError;
        private readonly ICalculatorData _calculatorData;
        private readonly ICommandInvoker<ICalculatorData, string> _commandInvoker;
        private readonly IComparer<ICommand<ICalculatorData, string>> _commandComparer;

        public Calculator(
            IStandardInput standardInput,
            IStandardOutput standardOutput,
            IStandardError standardError,
            ICalculatorData calculatorData,
            ICommandInvoker<ICalculatorData, string> commandInvoker,
            IComparer<ICommand<ICalculatorData, string>> commandComparer
            )
        {
            if (standardInput is null)
            {
                throw new ArgumentNullException(nameof(standardInput));
            }

            if (standardOutput is null)
            {
                throw new ArgumentNullException(nameof(standardOutput));
            }

            if (standardError is null)
            {
                throw new ArgumentNullException(nameof(standardError));
            }

            if (calculatorData is null)
            {
                throw new ArgumentNullException(nameof(calculatorData));
            }

            if (commandInvoker is null)
            {
                throw new ArgumentNullException(nameof(commandInvoker));
            }

            if (commandComparer is null)
            {
                throw new ArgumentNullException(nameof(commandComparer));
            }

            _standardInput = standardInput;
            _standardOutput = standardOutput;
            _standardError = standardError;
            _calculatorData = calculatorData;
            _commandInvoker = commandInvoker;
            _commandComparer = commandComparer;
        }

        public void Execute()
        {
            //int? first = null;
            //int? second = null;
            //string operation = null;

            while (!_calculatorData.Exit)
            {
                _standardOutput.WriteLine("-- MENU --");
                //_standardOutput.WriteLine("input) input a number");
                //_standardOutput.WriteLine("add) add command");
                //_standardOutput.WriteLine("subtract) subtract command");
                //_standardOutput.WriteLine("multiply) multiply command");
                //_standardOutput.WriteLine("divide) divide command");
                //_standardOutput.WriteLine("equals) equals command");
                //_standardOutput.WriteLine("quit) quit program");
                var commands = _commandInvoker.GetCommandIds().Where(x => x.Key != "invalid").ToArray();
                Array.Sort(commands, (x, y) => _commandComparer.Compare(x.Value, y.Value));
                foreach (var command in commands)
                {
                    _standardOutput.WriteLine($"{command.Key}) {((IMenuCommand)command.Value).MenuText}");
                }

                string input = _standardInput.ReadLine();
                if (_commandInvoker.IsValidOption(input))
                {
                    _commandInvoker.Execute(_calculatorData, input);
                }
                else
                {
                    _commandInvoker.Execute(_calculatorData, "invalid");
                }

                //switch (input)
                //{
                //    case "input":
                //        {
                //            if (first == null && operation == null)
                //            {
                //                first = int.Parse(_standardInput.ReadLine());
                //            }
                //            else if (operation != null && second == null)
                //            {
                //                second = int.Parse(_standardInput.ReadLine());
                //            }
                //            else
                //            {
                //                throw new InvalidOperationException("The input buffer is already full or there is no operation");
                //            }
                //        }
                //        break;
                //    case "add":
                //    case "subtract":
                //    case "multiply":
                //    case "divide":
                //        {
                //            if (first != null && operation == null)
                //            {
                //                operation = input;
                //            }
                //            else
                //            {
                //                throw new InvalidOperationException("The input buffer is already full");
                //            }
                //        }
                //        break;
                //    case "equals":
                //        {
                //            if (first != null && operation != null && second != null)
                //            {
                //                switch (operation)
                //                {
                //                    case "add":
                //                        first = first + second;
                //                        break;
                //                    case "subtract":
                //                        first = first - second;
                //                        break;
                //                    case "multiply":
                //                        first = first * second;
                //                        break;
                //                    case "divide":
                //                        first = first / second;
                //                        break;
                //                }
                //                operation = null;
                //                second = null;
                //                _standardOutput.WriteLine("result = " + first);
                //            }
                //        }
                //        break;
                //    case "quit":
                //        quit = true;
                //        break;
                //}
            }
        }
    }
}
