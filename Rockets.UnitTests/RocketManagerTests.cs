using Rockets.Lib;
using System.Drawing;
using Xunit;

namespace Rockets.UnitTests
{
    public class RocketManagerTests
    {
        private readonly RocketManager _rocketManager;
        public RocketManagerTests()
        {
            LandingPlatform landingPlatform = new LandingPlatform(10, 10, new Point(5, 5));
            LandingArea landingArea = new LandingArea(100, 100, landingPlatform);
            _rocketManager = new RocketManager(landingArea);
        }

        [Theory]
        [InlineData(16, 15)]
        [InlineData(15, 16)]
        [InlineData(50, 50)]
        [InlineData(-50, -50)]
        public void RocketCollisions_OneRocket_OutOfPlatform_Test(int x1, int y1)
        {
            Point[] rockets = new Point[] { new Point(x1, y1) };
            Assert.Equal(new string[] { Collisions.OutOfPlatform }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(7, 7)]
        [InlineData(3, 3)]
        [InlineData(7, 3)]
        [InlineData(3, 7)]
        public void RocketCollision_OneRocket_OkForLanding_Test(int x1, int y1)
        {
            Point[] rockets = new Point[] { new Point(x1, y1) };
            Assert.Equal(new string[] { Collisions.OkForLanding }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(7, 7, 7, 6)]
        [InlineData(7, 7, 7, 7)]
        [InlineData(7, 7, 7, 8)]
        [InlineData(7, 7, 6, 6)]
        [InlineData(7, 7, 6, 7)]
        [InlineData(7, 7, 6, 8)]
        [InlineData(7, 7, 8, 6)]
        [InlineData(7, 7, 8, 7)]
        [InlineData(7, 7, 8, 8)]
        public void RocketCollision_One_Clash_Test(int x1, int y1, int x2, int y2)
        {
            Point[] rockets1 = new Point[] { new Point(x1, y1) };
            Point[] rockets2 = new Point[] { new Point(x2, y2) };
            Assert.Equal(new string[] { Collisions.OkForLanding }, _rocketManager.RocketCollisions(rockets1));
            Assert.Equal(new string[] { Collisions.Clash }, _rocketManager.RocketCollisions(rockets2));
        }


        [Theory]
        [InlineData(16, 15, 25, 20)]
        [InlineData(15, 16, 20, 25)]
        [InlineData(50, 50, 30, 30)]
        [InlineData(-50, -50, 50, -50)]
        public void RocketCollisions_Two_OutOfPlatform_Test(int x1, int y1, int x2, int y2)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2) };
            Assert.Equal(new string[] { Collisions.OutOfPlatform, Collisions.OutOfPlatform }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(5, 5, 7, 7)]
        [InlineData(7, 7, 5, 5)]
        [InlineData(3, 3, 7, 7)]
        [InlineData(7, 3, 3, 7)]
        [InlineData(3, 7, 7, 3)]
        public void RocketCollisions_Two_OkForLanding_Test(int x1, int y1, int x2, int y2)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2) };
            Assert.Equal(new string[] { Collisions.OkForLanding, Collisions.OkForLanding }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(7, 7, 7, 6)]
        [InlineData(7, 7, 7, 7)]
        [InlineData(7, 7, 7, 8)]
        [InlineData(7, 7, 6, 6)]
        [InlineData(7, 7, 6, 7)]
        [InlineData(7, 7, 6, 8)]
        [InlineData(7, 7, 8, 6)]
        [InlineData(7, 7, 8, 7)]
        [InlineData(7, 7, 8, 8)]
        public void RocketCollisions_Two_Clash_Test(int x1, int y1, int x2, int y2)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2) };
            Assert.Equal(new string[] { Collisions.Clash, Collisions.Clash }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(7, 7, 7, 6, 7, 8)]
        [InlineData(7, 7, 7, 7, 7, 7)]
        [InlineData(7, 7, 7, 8, 7, 6)]
        [InlineData(7, 7, 6, 6, 7, 7)]
        [InlineData(7, 7, 6, 7, 7, 6)]
        [InlineData(7, 7, 6, 8, 8, 6)]
        [InlineData(7, 7, 8, 6, 6, 8)]
        [InlineData(7, 7, 8, 7, 7, 8)]
        [InlineData(7, 7, 8, 8, 8, 8)]
        public void RocketCollisions_Three_Clash_Test(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            Assert.Equal(new string[] { Collisions.Clash, Collisions.Clash, Collisions.Clash }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(5, 5, 70, 70)]
        [InlineData(7, 7, 50, 50)]
        [InlineData(3, 3, 70, 70)]
        [InlineData(7, 3, 30, 70)]
        [InlineData(3, 7, 70, 30)]
        public void RocketCollisions_One_OkForLanding_One_OutOfPlatform_Test(int x1, int y1, int x2, int y2)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2) };
            Assert.Equal(new string[] { Collisions.OkForLanding, Collisions.OutOfPlatform }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(5, 4, 7, 6, 6, 7)]
        [InlineData(5, 5, 7, 7, 7, 7)]
        [InlineData(5, 4, 7, 8, 7, 7)]
        [InlineData(4, 5, 6, 6, 7, 7)]
        [InlineData(4, 5, 6, 7, 7, 6)]
        [InlineData(8, 6, 6, 7, 6, 8)]
        [InlineData(6, 8, 7, 6, 8, 6)]
        [InlineData(5, 5, 8, 7, 7, 8)]
        [InlineData(5, 5, 8, 8, 8, 8)]
        public void RocketCollisions_One_OkForLanding_Two_Clash_Test(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
            Assert.Equal(new string[] { Collisions.OkForLanding, Collisions.Clash, Collisions.Clash }, _rocketManager.RocketCollisions(rockets));
        }

        [Theory]
        [InlineData(5, 4, 7, 6, 6, 7, 20, 20)]
        [InlineData(5, 5, 7, 7, 7, 7, 20, 20)]
        [InlineData(5, 4, 7, 8, 7, 7, 20, 20)]
        [InlineData(4, 5, 6, 6, 7, 7, 20, 20)]
        [InlineData(4, 5, 6, 7, 7, 6, 20, 20)]
        [InlineData(8, 6, 6, 7, 6, 8, 20, 20)]
        [InlineData(6, 8, 7, 6, 8, 6, 20, 20)]
        [InlineData(5, 5, 8, 7, 7, 8, 20, 20)]
        [InlineData(5, 5, 8, 8, 8, 8, 20, 20)]
        public void RocketCollisions_One_OkForLanding_One_OutOfPlatform_Two_Clash_Test(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            Point[] rockets = new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), new Point(x4, y4) };
            Assert.Equal(new string[] { Collisions.OkForLanding, Collisions.Clash, Collisions.Clash, Collisions.OutOfPlatform }, _rocketManager.RocketCollisions(rockets));
        }
    }
}
