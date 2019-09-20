using NSubstitute;
using NUnit.Framework;
using Shapez;
using Shapez.Adapters;

namespace Tests
{
    [TestFixture]
    public class TriangleProcessTests
    {
        private IDouble _double;
        private IConsole _console;
        
        private TriangleProcess _process;
                
        [SetUp]
        public void Setup()
        {
            _double = Substitute.For<IDouble>();
            _console = Substitute.For<IConsole>();
                        
            _process = new TriangleProcess(_console, _double);
        }

        [Test]
        public void AsksForBaseAndHeight_OrderMatters()
        {
            Run();
            Received.InOrder(() =>
                {
                    // TODO: this prompt pattern could probably be another class
                    _console.WriteLine("Please input base (as a double): ");
                    _console.ReadLine();
                    
                    _console.WriteLine("Please input height (as a double): ");
                    _console.ReadLine();
                } );
        }


        [Test]
        public void ParsesBaseAndHeight()
        {
            var first = "5.0";
            var second = "8.0";
            _console.ReadLine().Returns(first, second);

            Run();

            Received.InOrder(() => { 
                _double.Parse(first);
                _double.Parse(second);
            });
        }

        [Test]
        public void OutputsResult()
        {
            //real application would be more exhaustive on the calc tests
            // and probably would have a separate class for the calcs
            var base_ = 5.0;
            var height = 8.0;
            _double.Parse(Arg.Any<string>()).Returns(base_, height);

            string result = Run();
            
            Assert.That(result, Is.EqualTo($"Triangle with base {base_} and height {height} area is {(base_*height)/2}"));
        }

        private string Run()
        {
            return _process.Run();
        }
    }
}