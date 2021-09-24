using Akeraiotitasoft.Command.Abstractions;
using Akeraiotitasoft.DependencyInjection.Modules.Abstraction;
using Akeraiotitasoft.Samples.Calculator.Command;
using Akeraiotitasoft.Samples.Calculator.Library.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator.Library.DependencyInjection
{
    public class ServiceCollectionRegistration : IServiceCollectionModule
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // driver class
            serviceCollection.AddSingleton<ICalculator, Calculator>();
            
            // receiver class
            serviceCollection.AddSingleton<ICalculatorData, CalculatorData>();
            
            // command invoker
            serviceCollection.AddSingleton<ICommandInvoker<ICalculatorData, string>, CalculatorCommandInvoker>();

            // commands
            serviceCollection.AddSingleton<IMenuCommand, InvalidCommand>();
            serviceCollection.AddSingleton<IMenuCommand, InputCommand>();
            serviceCollection.AddSingleton<IMenuCommand, AddCommand>();
            serviceCollection.AddSingleton<IMenuCommand, SubtractCommand>();
            serviceCollection.AddSingleton<IMenuCommand, MultiplyCommand>();
            serviceCollection.AddSingleton<IMenuCommand, DivideCommand>();
            serviceCollection.AddSingleton<IMenuCommand, EqualsCommand>();
            serviceCollection.AddSingleton<IMenuCommand, QuitCommand>();

            // command comparer
            serviceCollection.AddSingleton<IComparer<ICommand<ICalculatorData, string>>, CommandComparer>();
        }
    }
}
