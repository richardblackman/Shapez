using Shapez;
using Shapez.Adapters;

namespace Shapez
{
    public class MainApplication
    {
        private readonly IConsole _console;
        private readonly IShapeProcessFactory _processFactory;

        public MainApplication(IConsole console, IShapeProcessFactory processFactory)
        {
            _console = console;
            _processFactory = processFactory;
        }

        public void Start()
        {
            _console.WriteLine(@"Hello and welcome to unfinished Shape calculation program 0.1");
            _console.WriteLine(@"Please choose a shape (case matters): ");
            _console.WriteLine(@"[C]ircle, [S]quare, [T]riangle");
            string shape = _console.ReadLine();

            IShapeProcess process = _processFactory.Get(shape);

            string result = process.Run();
            
            _console.WriteLine(result);
        }
    }
}