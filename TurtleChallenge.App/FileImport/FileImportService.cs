namespace TurtleChallenge.App.FileImport
{
    using Models.GameSettings;
    using Models.Movement;

    using Newtonsoft.Json;
    public static class FileImportService
    {
        /// <summary>
        /// Imports the game settings from a json file at the given path
        /// </summary>
        /// <param name="path">The full path to the json file</param>
        /// <returns>The game settings</returns>
        public static GameSettings ImportGameSettings(string path)
        {
            try
            {
                var json = File.ReadAllText(path);
                var gameSettings = JsonConvert.DeserializeObject<GameSettings>(json);

                if (gameSettings is null)
                {
                    Console.WriteLine("Error deserializing game settings file");

                    return null;
                }

                Console.WriteLine("Game Settings successfully imported!");

                return gameSettings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading game settings file! \n{ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Imports the moves from a json file at the given path
        /// </summary>
        /// <param name="path">The full path to the json file</param>
        /// <returns>The moves list</returns>
        public static IEnumerable<Move> ImportMoves(string path)
        {
            try
            {
                var json = File.ReadAllText(path);
                var moves = JsonConvert.DeserializeObject<List<Move>>(json);

                if (moves is null)
                {
                    Console.WriteLine("Error deserializing moves file");
                    
                    return null;
                }

                Console.WriteLine("Moves successfully imported!");

                return moves;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading moves file! \n{ex.Message}");
                return null;
            }
        }
    }
}