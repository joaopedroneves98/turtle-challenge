namespace TurtleChallenge.Tests.Models.Movement
{
    using AutoFixture;

    using FluentAssertions;

    using TurtleChallenge.App.Models.Movement;
    public class DirectionTest
    {
        private readonly IFixture _fixture;

        public DirectionTest()
        {
            this._fixture = new Fixture();
        }

        [Theory]
        [InlineData("north")]
        [InlineData("south")]
        [InlineData("west")]
        [InlineData("east")]
        public void DirectionConstructor_ValidDirectionValue_ShouldReturnNewInstance(string value)
        {
            // Act
            var result = new Direction(value);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(value);
        }

        [Fact]
        public void DirectionConstructor_InvalidDirectionValue_ShouldThrowException()
        {
            // Arrange
            var value = this._fixture.Create<string>();

            // Act
            var result = () => new Direction(value);

            // Assert
            result.Should().Throw<ArgumentException>();
        }
    }
}