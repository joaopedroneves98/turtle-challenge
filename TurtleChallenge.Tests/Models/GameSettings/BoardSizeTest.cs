namespace TurtleChallenge.Tests.Models.GameSettings
{
    using TurtleChallenge.App.Models.GameSettings;

    using AutoFixture;

    using FluentAssertions;
    public class BoardSizeTest
    {
        private readonly IFixture _fixture;

        public BoardSizeTest()
        {
            this._fixture = new Fixture();
        }

        [Fact]
        public void BoardSizeConstructor_ValidArguments_ShouldReturnNewInstance()
        {
            // Arrange
            var height = this._fixture.Create<int>();
            var width = this._fixture.Create<int>();

            // Act
            var result = new BoardSize(height, width);

            // Assert
            result.Should().NotBeNull();
            result.Height.Should().Be(height);
            result.Width.Should().Be(width);
        }
    }
}