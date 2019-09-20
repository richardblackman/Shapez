using Shapez.Adapters;

namespace Shapez
{
    public class TriangleProcess : IShapeProcess
    {
        private readonly IConsole _console;
        private readonly IDouble _dubl;

        public TriangleProcess(IConsole console, IDouble dubl)
        {
            _console = console;
            _dubl = dubl;
        }

        public string Run()
        {
            _console.WriteLine("Please input base (as a double): ");
            string inputBase = _console.ReadLine();
            _console.WriteLine("Please input height (as a double): ");
            string inputHeight = _console.ReadLine();

            double base_ = _dubl.Parse(inputBase);
            double height = _dubl.Parse(inputHeight);

            return $"Triangle with base {base_} and height {height} area is {(base_ * height) / 2}";
        }
    }
}