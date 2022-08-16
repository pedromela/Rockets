using System.Collections.Generic;
using System.Drawing;

namespace Rockets.Lib
{
    public class LandingArea : Platform
    {
        public LandingPlatform LandingPlatform { get; private set; }
        public List<Point> LastRockets{ get; private set; }

        public LandingArea(int width, int height, LandingPlatform landingPlatform)
        : base(width, height, new Point(0, 0))
        {
            LandingPlatform = landingPlatform;
            LastRockets = new List<Point>();
        }
    }
}
