namespace TurtleChallenge.Tests.Models.Movement
{
    using TurtleChallenge.App.Models.Movement;

    using AutoFixture;

    using FluentAssertions;
    public class MoveTest
    {
        private readonly IFixture _fixture;

        public MoveTest()
        {
            this._fixture = new Fixture();
        }

        [Fact]
        public void MoveConstructor_InvalidAction_ShouldThrowException()
        {
            // Arrange
            var action = this._fixture.Create<string>();

            // Act
            var result = () => new Move(action);

            // Assert
            result.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("move")]
        [InlineData("rotate")]
        public void MoveConstructor_ValidAction_ShouldNotThrowException(string action)
        {
            // Act
            var result = new Move(action);

            // Assert
            result.Should().NotBeNull();
            result.Action.Should().Be(action);
        }
    }
}