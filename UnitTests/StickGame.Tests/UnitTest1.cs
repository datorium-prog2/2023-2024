using UnitTests;

namespace StickGame.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void When_StartGameAndPlayerIsStarting_Then_ItsPlayersTurn() // Ja notiek X, tad notiek Y
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: true);

            Assert.True(stickGame.IsPlayersTurn);
        }
    }
}