using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Rockets.Lib
{
    public class Collisions
    {
        public const string OutOfPlatform = "out of platform";
        public const string Clash = "clash";
        public const string OkForLanding = "ok for landing";
        public const int RocketWidth = 3;
        public const int  RocketHeight = 3;

        private static bool InsideRectangle(Point p, Point anchor, int width, int height)
        {
            var platformRect = new Rectangle(anchor.X, anchor.Y, width, height);
            return platformRect.Contains(p.X, p.Y);
        }

        private static bool InsidePlatform(Point p, IPlatform platform)
        {
            return InsideRectangle(p, platform.Point, platform.Width, platform.Height);
        }

        private static bool InsidePlatformCentered(Point p, IPlatform platform)
        {
            return InsidePlatform(new Point(p.X + platform.Width / 2, p.Y + platform.Height / 2), platform);
        }

        private static bool LastRocketsCollision(Point p, int width, int height, List<Point> lastRockets)
        {
            foreach (var position in lastRockets)
            {
                if (InsidePlatformCentered(p, new Platform(height, height, position)))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Collision(Point p, LandingArea platform)
        {
            if (!InsidePlatform(p, platform) || !InsidePlatformCentered(p, platform.LandingPlatform))
            {
                return OutOfPlatform;
            }
            else if (platform.LastRockets.Count() > 0 && LastRocketsCollision(p, RocketWidth, RocketHeight, platform.LastRockets))
            {
                return Clash;
            }
            else
            {
                return OkForLanding;
            }
        }
    }
}
