using System;

namespace Shapez.Adapters
{
    public class DoubleAdapter : IDouble
    {
        public double Parse(string parseable)
        {
            return double.Parse(parseable);
        }
    }
}