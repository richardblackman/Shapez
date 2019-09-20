using Shapez.Adapters;

namespace Shapez
{
    public class SquareProcess : IShapeProcess
    {
        private readonly IConsole _console;
        private readonly IDouble _dubl;

        public SquareProcess(IConsole console, IDouble dubl)
        {
            _console = console;
            _dubl = dubl;
        }

        public string Run()
        {
            _console.WriteLine("Please input width (as a double): ");
            string input = _console.ReadLine();

            double parsed = _dubl.Parse(input);

            return $"Square of width {parsed} is {parsed * parsed}";
        }
    }
}