using Akeraiotitasoft.ConsoleDriving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akeraiotitasoft.Samples.Calculator
{
    public class Driver : IDriver
    {
        private readonly ICalculator _calculator;

        public Driver(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator), $"{nameof(calculator)} cannot be null");
        }

        public async Task<int> ExecuteAsync(string[] args, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
            {
                _calculator.Execute();
                return 0;
            });
        }
    }
}
