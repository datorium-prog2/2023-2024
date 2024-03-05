using System;
using UnitTests;

namespace StickGame.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void When_StartGameAndPlayerIsStarting_Then_ItsPlayersTurn() // Ja notiek X, tad notiek Y
        {
            // Arrange
            var stickGame = new _21StickGame();

            // Act
            stickGame.StartGame(isPlayerStarting: true);

            // Assert
            Assert.True(stickGame.IsPlayersTurn);
        }

        [Fact]
        public void When_PlayerMoves_Then_ItsNotPlayersTurn()
        {
            //Arrange
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: true);

            //Act
            stickGame.PlayerMove(2);

            //Assert
            Assert.False(stickGame.IsPlayersTurn);
        }

        [Fact]
        public void When_PlayerTakes2Sticks_Then_StickCountIsReducedBy2()
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: true);
            stickGame.PlayerMove(2);

            Assert.Equal(19, stickGame.StickCount);
        }

        [Fact]
        public void When_ComputerMoveAndThereIs21Sticks_Then_StickCountIsReducedBy2()
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: false);
            stickGame.ComputerMove();

            Assert.Equal(19, stickGame.StickCount);
        }

        [Fact]
        public void When_ComputerFinishesMoves_Then_IsPlayersTurnTrue()
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: false);
            stickGame.ComputerMove();

            Assert.True(stickGame.IsPlayersTurn);
        }

        [Fact]
        public void When_ComputerMoveAndThereIs20Sticks_Then_StickCountIsReducedBy1()
        {
            //Arrange
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: false, stickCount: 20);

            //Act
            stickGame.ComputerMove();

            //Assert
            Assert.Equal(19, stickGame.StickCount);
        }

        [Fact]
        public void When_ComputerMoveAndPlayerTriesToMove_Then_ThrowException()
        {
            // Arrange
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: false);

            //Act, Assert
            var exception = Assert.Throws<Exception>(() => { stickGame.PlayerMove(2); });
            Assert.Equal("Not a player's move", exception.Message);
        }

        [Fact]
        public void When_PlayerTriesToTakeInvalidStickCount_Then_ThrowException()
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: true);
            var exception = Assert.Throws<Exception>(() => { stickGame.PlayerMove(5); });
            Assert.Equal("Invalid stick count", exception.Message);
        }

        [Fact]
        public void When_PlayerMoveAndComputerTriesToMove_Then_ThrowException()
        {
            var stickGame = new _21StickGame();
            stickGame.StartGame(isPlayerStarting: true);
            var exception = Assert.Throws<Exception>(() => { stickGame.ComputerMove(); });
            Assert.Equal("Not a computer's move", exception.Message);
        }
    }
}