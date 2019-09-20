using System;
using Shapez.Adapters;

namespace Shapez
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                GetMainApplication().Start();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine("Please try again");
                Console.WriteLine("A real app would have better (and unit tested) error handling :)");
            }
        }

        
        // TODO: in a real application this would be in a container class
        private static MainApplication GetMainApplication()
        {
            return new MainApplication(new ConsoleAdapter(), new ShapeProcessFactory());
        }
    }
}