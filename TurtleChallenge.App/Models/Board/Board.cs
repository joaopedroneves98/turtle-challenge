namespace TurtleChallenge.App.Models.Board
{
    using GameSettings;

    using Movement;

    using Turtle;
    public class Board
    {
        public Board(GameSettings gameSettings)
        {
            this.Turtle = new Turtle(gameSettings.Direction, gameSettings.StartingPosition.X - 1, gameSettings.StartingPosition.Y - 1);
            this.GameBoard = this.BuildBoard(gameSettings);
        }
        
        public char[][] GameBoard { get; set; }

        public Turtle Turtle { get; set; }
        
        /// <summary>
        /// Executes a given move on the Turtle
        /// </summary>
        /// <param name="move">Move to be executed</param>
        public void Play(Move move)
        {
            if (string.Equals(move.Action, "rotate", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Rotate!");
                this.Turtle.Rotate();
                return;
            }

            this.Turtle.Move();

            switch (this.GameBoard[this.Turtle.Position.Y][this.Turtle.Position.X])
            {
                case 'x':
                    Console.WriteLine("Mine hit!");
                    this.Turtle.MineHit();
                    return;
                case 'e':
                    Console.WriteLine("Exit reached!");
                    this.Turtle.ExitReached();
                    return;
                default:
                    Console.WriteLine("Success!");
                    break;
            }
        }

        /// <summary>
        /// Prints the current board to Console
        /// </summary>
        public void Print()
        {
            Console.WriteLine("   " + string.Join(" ", Enumerable.Range(1, this.GameBoard[0].Length).Select(c => c)));
            for (var i = 0; i < this.GameBoard.Length; i++)
            {
                Console.Write(i + 1 + " ");
                for (var j = 0; j < this.GameBoard[i].Length; j++)
                {
                    Console.Write("|" + this.GameBoard[i][j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("   " + string.Join(" ", Enumerable.Range(1, this.GameBoard[0].Length).Select(c => c)));
            Console.WriteLine("b = beginning\nx = mine\ne = exit");
        }

        /// <summary>
        /// Initializes the Game Board with the given game settings
        /// </summary>
        /// <param name="gameSettings">The settings to initialize the board with</param>
        /// <returns>The game board</returns>
        private char[][] BuildBoard(GameSettings gameSettings)
        {
            var board = new char[gameSettings.BoardSize.Height][];

            for (var i = 0; i < gameSettings.BoardSize.Height; i++)
            {
                board[i] = new char[gameSettings.BoardSize.Width];
                for (var j = 0; j < gameSettings.BoardSize.Width; j++)
                {
                    board[i][j] = ' ';
                }
            }

            foreach (var mine in gameSettings.Mines)
            {
                board[mine.Y - 1][mine.X - 1] = 'x';
            }

            board[gameSettings.StartingPosition.Y - 1][gameSettings.StartingPosition.X - 1] = 'b';
            board[gameSettings.ExitPoint.Y - 1][gameSettings.ExitPoint.X - 1] = 'e';

            return board;
        }
    }
}