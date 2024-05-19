namespace TurtleChallenge.App.Models.GameSettings
{
    using Movement;
    public class GameSettings
    {
        public GameSettings(
            Coordinates startingPosition,
            Coordinates exitPoint,
            BoardSize boardSize,
            string direction,
            IEnumerable<Coordinates> mines)
        {
            this.StartingPosition = startingPosition;
            this.ExitPoint = exitPoint;
            this.BoardSize = boardSize;
            this.Mines = mines;
            this.Direction = new Direction(direction);
        }

        public Coordinates StartingPosition { get; set; }

        public Coordinates ExitPoint { get; set; }

        public BoardSize BoardSize { get; set; }

        public Direction Direction { get; set; }

        public IEnumerable<Coordinates> Mines { get; set; }
    }
}