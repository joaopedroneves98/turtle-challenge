namespace TurtleChallenge.App.Models.GameSettings
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            this.X = x is < 0 ? throw new ArgumentOutOfRangeException(nameof(x), "Coordinates can't be less than 0") : x;
            this.Y = y is < 0 ? throw new ArgumentOutOfRangeException(nameof(y), "Coordinates can't be less than 0") : y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}