namespace TurtleChallenge.Tests.Models.GameSettings
{
    using AutoFixture;

    using FluentAssertions;

    using TurtleChallenge.App.Models.GameSettings;
    public class GameSettingsTest
    {
        private readonly IFixture _fixture;
        
        public GameSettingsTest()
        {
            this._fixture = new Fixture();
        }

        [Fact]
        public void GameSettingsConstructor_ValidArguments_ShouldReturnNewInstance()
        {
            // Arrange
            var startingPosition = this._fixture.Create<Coordinates>();
            var exitPosition = this._fixture.Create<Coordinates>();
            var mines = this._fixture.CreateMany<Coordinates>();
            var boardSize = this._fixture.Create<BoardSize>();
            var direction = "north";

            // Act
            var result = new GameSettings(startingPosition, exitPosition, boardSize, direction, mines);

            // Assert
            result.Should().NotBeNull();
            result.StartingPosition.Should().Be(startingPosition);
            result.ExitPoint.Should().Be(exitPosition);
            result.Mines.Should().BeEquivalentTo(mines);
            result.BoardSize.Should().Be(boardSize);
            result.Direction.Value.Should().Be(direction);
        }
    }
}