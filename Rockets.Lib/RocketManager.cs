using System.Drawing;

namespace Rockets.Lib
{
    public class RocketManager
    {
        private readonly LandingArea _board;
        public RocketManager(LandingArea board)
        {
            _board = board;
        }

        public string[] RocketCollisions(params Point[] rockets)
        {
            string[] results = new string[rockets.Length];
            _board.LastRockets.AddRange(rockets);
            for (int i = 0; i < rockets.Length; i++)
            {
                _board.LastRockets.Remove(rockets[i]);
                results[i] = Collisions.Collision(rockets[i], _board);
                _board.LastRockets.Add(rockets[i]);

            }
            _board.LastRockets.Clear();// Clear last check. Only last check counts.
            _board.LastRockets.AddRange(rockets);
            return results;
        }
    }
}
