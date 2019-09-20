using System;
using Shapez.Adapters;

namespace Shapez
{
    public class ShapeProcessFactory : IShapeProcessFactory
    {
        //In a real app these might be separate factories and/or created via IoC container
        //generally would be a Func<IShapeProcess> dependency.
        public IShapeProcess Get(string shapeCode)
        {
            switch (shapeCode)
            {
                case "C":
                    return new CircleProcess(new ConsoleAdapter(), new DoubleAdapter());
                case "S":
                    return new SquareProcess(new ConsoleAdapter(), new DoubleAdapter());
                case "T":
                    return new TriangleProcess(new ConsoleAdapter(), new DoubleAdapter());
                default:
                    throw new Exception("Invalid shape");
            }
        }
    }
}