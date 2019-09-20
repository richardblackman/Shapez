using System;
using Shapez.Adapters;

namespace Shapez
{
    public class CircleProcess : IShapeProcess
    {
        private readonly IConsole _console;
        private readonly IDouble _dubl;

        public CircleProcess(IConsole console, IDouble dubl)
        {
            _console = console;
            _dubl = dubl;
        }

        public string Run()
        {
            _console.WriteLine("Please input radius (as a double): ");
            string line = _console.ReadLine();

            double radius = _dubl.Parse(line);

            return $"Circle area for radius of {radius} is {Math.PI * radius * radius}";
        }
    }
}