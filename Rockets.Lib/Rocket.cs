using System.Drawing;

namespace Rockets.Lib
{
    public class Rocket
    {
        public Point Point { get; private set; }
        public Rocket(int x, int y)
        {
            Point = new Point(x, y);
        }
    }
}
