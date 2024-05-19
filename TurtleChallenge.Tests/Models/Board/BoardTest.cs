namespace TurtleChallenge.Tests.Models.Board
{
    using App.Models.GameSettings;

    using App.Models.Board;
    using App.Models.Movement;

    using FluentAssertions;
    public class BoardTest
    {

        [Fact]
        public void BoardConstructor_ValidGameSettings_ShouldReturnNewInstance()
        {
            // Arrange
            var gameSettings = new GameSettings(
                new Coordinates(1, 1),
                new Coordinates(5, 5),
                new BoardSize(5, 5),
                "east",
                new List<Coordinates>());

            // Act
            var result = new Board(gameSettings);

            // Assert
            result.Should().NotBeNull();
            
            result.Turtle.Should().NotBeNull();
            result.Turtle.Direction.Value.Should().Be("east");
            result.Turtle.Position.X.Should().Be(0);
            result.Turtle.Position.Y.Should().Be(0);
            
            result.GameBoard.Should().NotBeNull();
            result.GameBoard.Length.Should().Be(5);
        }

        [Fact]
        public void Play_ValidMoveMove_ShouldExecuteMove()
        {
            // Arrange
            var direction = "east";
            var gameSettings = new GameSettings(
                new Coordinates(1, 1),
                new Coordinates(5, 5),
                new BoardSize(5, 5),
                direction,
                new List<Coordinates>());

            var board = new Board(gameSettings);

            var move = new Move("move");
            
            // Act
            board.Play(move);
            
            // Assert
            board.Turtle.Position.X.Should().Be(1);
            board.Turtle.Position.Y.Should().Be(0);
            board.Turtle.Direction.Value.Should().Be(direction);
        }
        
        [Fact]
        public void Play_ValidRotateMove_ShouldExecuteMove()
        {
            // Arrange
            var direction = "east";
            var gameSettings = new GameSettings(
                new Coordinates(1, 1),
                new Coordinates(5, 5),
                new BoardSize(5, 5),
                direction,
                new List<Coordinates>());

            var board = new Board(gameSettings);

            var move = new Move("rotate");
            
            // Act
            board.Play(move);
            
            // Assert
            board.Turtle.Position.X.Should().Be(0);
            board.Turtle.Position.Y.Should().Be(0);
            board.Turtle.Direction.Value.Should().NotBe(direction);
            board.Turtle.Direction.Value.Should().Be("south");
        }
    }
}