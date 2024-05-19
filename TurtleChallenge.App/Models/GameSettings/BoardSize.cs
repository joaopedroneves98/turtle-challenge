namespace TurtleChallenge.App.Models.GameSettings
{
    public class BoardSize
    {
        public BoardSize(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
        
        public int Height { get; set; }

        public int Width { get; set; }
    }
}