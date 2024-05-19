namespace TurtleChallenge.App.Models.Turtle
{
    using GameSettings;

    using Movement;
    public class Turtle
    {
        public Turtle(Direction direction, int startingPositionX, int startingPositionY)
        {
            this.Direction = direction;
            this.Position = new Coordinates(startingPositionX, startingPositionY);
        }
        
        public Coordinates Position { get; }

        public Direction Direction { get; }

        public bool Exited { get; private set; }
        
        public bool HitByMine { get; private set; }

        public void MineHit()
        {
            this.HitByMine = true;
        }

        public void ExitReached()
        {
            this.Exited = true;
        }

        /// <summary>
        /// Moves the turtle position given its current direction
        /// </summary>
        public void Move()
        {
            switch (this.Direction.Value)
            {
                case "north":
                    this.Position.Y -= 1;
                    break;

                case "east":
                    this.Position.X += 1;
                    break;

                case "west":
                    this.Position.X -= 1;
                    break;

                case "south":
                    this.Position.Y += 1;
                    break;
            }
        }

        /// <summary>
        /// Rotates the direction of the turtle 90 degrees to the right
        /// </summary>
        public void Rotate()
        {
            this.Direction.Value = this.Direction.Value switch
            {
                "north" => "east",
                "east" => "south",
                "south" => "west",
                "west" => "north",
                _ => this.Direction.Value
            };
        }
    }
}