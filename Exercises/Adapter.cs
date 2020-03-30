using System;
namespace Exercises
{
    public class Square
    {
        public int Side;
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private int width, height;

        public SquareToRectangleAdapter(Square square)
        {
            width = square.Side;
            height = square.Side;
        }

        public int Height => this.height;

        public int Width => this.width;
    }
}