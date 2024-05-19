namespace TurtleChallenge.Tests.Models.GameSettings
{
    using TurtleChallenge.App.Models.GameSettings;

    using FluentAssertions;
    public class CoordinatesTest
    {

        [Fact]
        public void CoordinatesConstructor_ValidArguments_ShouldReturnNewInstance()
        {
            // Arrange
            var x = 1;
            var y = 1;

            // Act
            var result = new Coordinates(x, y);

            // Assert
            result.Should().NotBeNull();
            result.X.Should().Be(x);
            result.Y.Should().Be(y);
        }
        
        [Fact]
        public void CoordinatesConstructor_InvalidArguments_ShouldThrowException()
        {
            // Arrange
            var x = -1;
            var y = -1;

            // Act
            var result = () => new Coordinates(x, y);

            // Assert
            result.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}