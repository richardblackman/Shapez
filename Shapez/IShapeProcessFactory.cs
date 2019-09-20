namespace Shapez
{
    public interface IShapeProcessFactory
    {
        IShapeProcess Get(string shapeCode);
    }
}