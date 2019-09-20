using System;

namespace Shapez.Adapters
{
    public class ConsoleAdapter : IConsole
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}