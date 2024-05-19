namespace TurtleChallenge.Tests.Models.Turtle
{
    using App.Models.Movement;
    using App.Models.Turtle;

    using FluentAssertions;

    public class TurtleTest
    {

        [Fact]
        public void TurtleConstructor_ValidArguments_ShouldReturnNewInstance()
        {
            // Arrange
            var direction = new Direction("east");
            var startX = 0;
            var startY = 0;

            // Act
            var result = new Turtle(direction, startX, startY);

            // Assert
            result.Should().NotBeNull();
            result.Direction.Should().Be(direction);
            result.Position.Y.Should().Be(startY);
            result.Position.X.Should().Be(startX);
        }

        [Theory]
        [InlineData("north", 0, 0, 1, 0)]
        [InlineData("east", 0, 1, 1, 1)]
        [InlineData("south", 0, 0, 1, 2)]
        [InlineData("west", 1, 0, 1, 1)]
        public void Move_ValidArguments_ShouldChangeCoordinates(string direction, int initialX, int finalX, int initialY, int finalY)
        {
            // Arrange
            var turtle = new Turtle(new Direction(direction), initialX, initialY);

            // Act
            turtle.Move();

            // Assert
            turtle.Should().NotBeNull();
            turtle.Direction.Value.Should().Be(direction);
            turtle.Position.Y.Should().Be(finalY);
            turtle.Position.X.Should().Be(finalX);
        }

        [Theory]
        [InlineData("north", "east")]
        [InlineData("east", "south")]
        [InlineData("south", "west")]
        [InlineData("west", "north")]
        public void Rotate_ValidArguments_ShouldChangeDirection(string initalDirection, string finalDirection)
        {
            // Arrange
            var turtle = new Turtle(new Direction(initalDirection), 0, 0);

            // Act
            turtle.Rotate();

            // Assert
            turtle.Should().NotBeNull();
            turtle.Direction.Value.Should().Be(finalDirection);
        }
    }
}