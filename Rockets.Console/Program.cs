using Rockets.Lib;

namespace Rockets.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LandingPlatform landingPlatform = new LandingPlatform(10, 10, new System.Drawing.Point(5, 5));
            LandingArea landingArea = new LandingArea(100, 100, landingPlatform);
            RocketManager rocketManager = new RocketManager(landingArea);
        }
    }
}
