using NSubstitute;
using NUnit.Framework;
using Shapez.Adapters;
using Shapez;

namespace Tests
{
    public class MainApplicationTests
    {
        private IConsole _console;
        
        private MainApplication _application;
        private IShapeProcessFactory _processFactory;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _processFactory = Substitute.For<IShapeProcessFactory>();
            
            _application = new MainApplication(_console, _processFactory);
        }

        [Test]
        public void PrintsAWelcomeMessage()
        {
            Start();

            AssertConsoleWroteLine(@"Hello and welcome to unfinished Shape calculation program 0.1");
        }

        [Test]
        public void AsksForAShape()
        {
            Start();

            AssertConsoleWroteLine("Please choose a shape (case matters): ");
        }

        [Test]
        public void OutputsShapeOptions()
        {
            Start();
            
            AssertConsoleWroteLine("[C]ircle, [S]quare, [T]riangle");
        }

        [Test]
        public void ReadsShapeOption()
        {
            Start();

            _console.Received().ReadLine();
        }

        [Test]
        public void AsksFactoryForShapeProcess()
        {
            var shape = "chosenShape";
            _console.ReadLine().Returns(shape);
            Start();

            _processFactory.Received().Get(shape);
        }

        [Test]
        public void RunsShapeProcess()
        {
            var shapeProcess = StubShapeProcess();
            
            Start();

            shapeProcess.Received().Run();
        }

        [Test]
        public void PrintsShapeResult()
        {
            string shapeProcessResult = "resultStub";

            var shapeProcess = StubShapeProcess();
            shapeProcess.Run().Returns(shapeProcessResult);
            
            Start();
            
            _console.Received().WriteLine(shapeProcessResult);
        }

        [Test]
        public void RunsFileSaveProcess()
        {
            //TODO
        }

        private void AssertConsoleWroteLine(string output)
        {
            _console.Received().WriteLine(output);
        }

        private void Start()
        {
            _application.Start();
        }

        private IShapeProcess StubShapeProcess()
        {
            var shapeProcess = Substitute.For<IShapeProcess>();
            _processFactory.Get(Arg.Any<string>()).Returns(shapeProcess);
            return shapeProcess;
        }
    }
}