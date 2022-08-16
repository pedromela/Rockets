using System.Drawing;

namespace Rockets.Lib
{
    interface IPlatform
    {
        int Height { get; }
        int Width { get; }
        Point Point { get; }
    }
}
