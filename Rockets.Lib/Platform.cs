using System.Drawing;

namespace Rockets.Lib
{
    public class Platform : IPlatform
    {
        private int _height;
        public int Height { get => _height; }
        private int _width;
        public int Width { get => _width; }
        private Point _Point;
        public Point Point { get => _Point; }

        public Platform(int width, int height, Point Point)
        {
            _width = width;
            _height = height;
            _Point = Point;
        }
    }
}
