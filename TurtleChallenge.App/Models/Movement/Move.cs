namespace TurtleChallenge.App.Models.Movement
{
    public class Move
    {
        private readonly List<string> _allowedActions = ["move", "rotate"];

        public Move(string action)
        {
            if (!this._allowedActions.Contains(action, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid action: " + action);
            }
            
            this.Action = action.ToLower();
        }

        public string Action { get; }
    }
}