using System;
using NSubstitute;
using NUnit.Framework;
using Shapez;
using Shapez.Adapters;

namespace Tests
{
    [TestFixture]
    public class CircleProcessTests
    {
        private IDouble _double;
        private IConsole _console;
        
        private CircleProcess _process;
        
        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _double = Substitute.For<IDouble>();
            
            _process = new CircleProcess(_console, _double);     
        }

        [Test]
        public void AsksForRadius()
        {
            Run();

            Received.InOrder(() =>
                {
                    _console.WriteLine("Please input radius (as a double): ");
                    _console.ReadLine();
                } );
        }

        [Test]
        public void ParsesRadius()
        {
            var inputRadius = "inputRadius";
            _console.ReadLine().Returns(inputRadius);
            
            Run();

            _double.Received().Parse(inputRadius);
        }

        [Test]
        public void OutputsResult()
        {
            // real app would have separate calculation and tests
            var parsedRadius = 3.5;
            _double.Parse(Arg.Any<string>()).Returns(parsedRadius);

            var result = Run();

            Assert.That(result, Is.EqualTo($"Circle area for radius of {parsedRadius} is {Math.PI * parsedRadius * parsedRadius}"));
        }

        private string Run()
        {
            return _process.Run();
        }
    }
}