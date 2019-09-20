using System;
using NUnit.Framework;
using Shapez;

namespace Tests
{
    [TestFixture]
    public class ShapeProcessFactoryTests
    {
        private IShapeProcessFactory _factory;
        
        [SetUp]
        public void Setup()
        {
            _factory = new ShapeProcessFactory();
        }

        [Test]
        public void C_ReturnsCircleProcess()
        {
            AssertProcessIs<CircleProcess>("C");
        }

        [Test]
        public void T_ReturnsTriangleProcess()
        {
            AssertProcessIs<TriangleProcess>("T");
        }

        [Test]
        public void S_ReturnsSquareProcess()
        {
            AssertProcessIs<SquareProcess>("S");
        }

        [Test]
        public void Invalid_ThrowsException()
        {
            // TODO: a real app would have a more exhaustive test (maybe)
            Assert.Throws<Exception>(() => _factory.Get("blah"));
        }

        private void AssertProcessIs<T>(string shapeCode)
        {
            IShapeProcess result = _factory.Get(shapeCode);

            Assert.That(result, Is.TypeOf<T>());
        }
    }
}