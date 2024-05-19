namespace TurtleChallenge.App.Models.Movement
{
    public class Direction
    {
        private readonly List<string> _allowedDirections = ["north", "east", "west", "south"];
        
        public Direction(string value)
        {
            if (!this._allowedDirections.Contains(value, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid direction: " + value);
            }
            
            this.Value = value.ToLower();
        }

        public string Value { get; set; }
    }
}