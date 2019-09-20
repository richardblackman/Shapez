using System;
using NSubstitute;
using NUnit.Framework;
using Shapez;
using Shapez.Adapters;

namespace Tests
{
    [TestFixture]
    public class SquareProcessTests
    {
        private IDouble _double;
        private IConsole _console;

        private SquareProcess _process;
        
        [SetUp]
        public void Setup()
        {
            _double = Substitute.For<IDouble>();
            _console = Substitute.For<IConsole>();
            
            _process = new SquareProcess(_console, _double);
        }

        [Test]
        public void AsksForWidth()
        {
            Run();

            Received.InOrder(() =>
                {
                    // TODO: this prompt pattern could probably be another class
                    _console.WriteLine("Please input width (as a double): ");
                    _console.ReadLine();
                } );
        }

        [Test]
        public void ParsesWidth()
        {
            var inputWidth = "inputWidth";
            _console.ReadLine().Returns(inputWidth);
            
            Run();

            _double.Received().Parse(inputWidth);
        }

        [Test]
        public void OutputsResult()
        {
            var parsedWidth = 5.0;
            _double.Parse(Arg.Any<string>()).Returns(parsedWidth);
            
            string result = Run();
            
            Assert.That(result, Is.EqualTo($"Square of width {parsedWidth} is {parsedWidth*parsedWidth}"));
        }

        private string Run()
        {
            return _process.Run();
        }
    }
    
}