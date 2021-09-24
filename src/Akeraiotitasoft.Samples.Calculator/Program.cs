using Akeraiotitasoft.ConsoleDriving;
using Akeraiotitasoft.DependencyInjection.Modules;
using Akeraiotitasoft.IOFacade.DependencyInjection;
using Akeraiotitasoft.Samples.Calculator.Library.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace Akeraiotitasoft.Samples.Calculator
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                // run the program
                return CreateConsoleDriverBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                // write the exception to the error stream
                Console.Error.WriteLine(ex);

                // return COM exception code
                if (ex.HResult != 0)
                {
                    return ex.HResult;
                }
                // return -1 to indicate some other error
                return -1;
            }
        }

        public static IConsoleDriverBuilder CreateConsoleDriverBuilder(string[] args) =>
            ConsoleDriver.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((drivingContext, configurationBuilder) =>
               {
                   // base path
                   string basePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                   configurationBuilder.SetBasePath(basePath);
                   configurationBuilder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: false);
                   if (!string.IsNullOrEmpty(drivingContext.ConsoleDrivingEnvironment.EnvironmentName))
                   {
                       configurationBuilder.AddJsonFile(path: $"appsettings.{drivingContext.ConsoleDrivingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false);
                   }
                   configurationBuilder.AddEnvironmentVariables("FLATS_");
                   configurationBuilder.AddCommandLine(args);


               })
            .ConfigureConsoleDriverConfiguration(configurationBuilder =>
            {

            })
            .ConfigureLogging( logging =>
            {
                logging.AddConsole();
            })
            .ConfigureServices(services =>
            {
                services.LoadModule<ServiceCollectionRegistration>();
                services.AddFacadeIO();
                services.AddDriver<Driver>();
            });
    }
}
