namespace TurtleChallenge.App
{
    using FileImport;

    internal class Program
    {
        static void Main(string[] args)
        {
            var gameSettingsPath = args.ElementAtOrDefault(0);
            var movesPath = args.ElementAtOrDefault(1);

            if (gameSettingsPath is null || movesPath is null)
            {
                Console.WriteLine("Please enter the full path for the game settings file:");
                gameSettingsPath = Console.ReadLine();

                Console.WriteLine("Please enter the full path for the moves file:");
                movesPath = Console.ReadLine();
            }

            var gameSettings = FileImportService.ImportGameSettings(gameSettingsPath);
            if (gameSettings is null)
            {
                Console.WriteLine("Failed to import game settings!");
                Environment.Exit(1);
            }

            var moves = FileImportService.ImportMoves(movesPath);
            if (moves is null)
            {
                Console.WriteLine("Failed to import moves!");
                Environment.Exit(1);
            }

            var board = new Models.Board.Board(gameSettings);

            Console.WriteLine("Initial board:");
            board.Print();

            try
            {
                for (var i = 0; i < moves.Count(); i++)
                {
                    Console.Write($"Sequence {i + 1}: ");
                    board.Play(moves.ElementAt(i));
                    
                    if (board.Turtle.HitByMine)
                    {
                        Console.WriteLine("The turtle was hit by a mine and unable to reach the exit!");
                        break;
                    }

                    if (board.Turtle.Exited)
                    {
                        Console.WriteLine("The turtle was able to exit!");
                        break;
                    }
                }

                if (board.Turtle is { HitByMine: false, Exited: false })
                {
                    Console.WriteLine("The turtle didn't reach the exit and wasn't hit by any mine!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Move out of bounds!");
            }
        }
    }
}