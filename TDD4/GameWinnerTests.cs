using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TDD4
{
    [TestFixture]
    public class GameWinnerTests
    {
        [TestCase(0, 3, GameWinner.Player2)]
        [TestCase(3, 0, GameWinner.Player1)]
        public void ThreeWonRoundsWinGame(int player1Score, int player2Score, GameWinner expectedWinner)
        {
            var game = new Game
            {
                Player1Wins = player1Score,
                Player2Wins = player2Score
            };
            game.GetWinner().Should().Be(expectedWinner);
        }
        
        [TestCase(0, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 2)]
        [TestCase(1, 1)]
        public void LessThanThreeRoundsWithNoDrawsShouldBeUndecided(int player1Score, int player2Score)
        {
            var game = new Game
            {
                Player1Wins = player1Score,
                Player2Wins = player2Score
            };
            game.GetWinner().Should().Be(GameWinner.Undecided);
        }

        [TestCase(1, 2, GameWinner.Player2)]
        [TestCase(2, 1, GameWinner.Player1)]
        public void ClearWinnerAfterThreeRoundsWithNoDrawsShouldWin(int player1Score, int player2Score, GameWinner expectedWinner)
        {
            var game = new Game
            {
                Player1Wins = player1Score,
                Player2Wins = player2Score
            };
            game.GetWinner().Should().Be(expectedWinner);
        }

        [TestCase(1, 2, 1, GameWinner.Player2)]
        [TestCase(1, 0, 1, GameWinner.Undecided)]
        [TestCase(1, 1, 1, GameWinner.Undecided)]
        [TestCase(2, 0, 1, GameWinner.Player1)]
        [TestCase(2, 1, 1, GameWinner.Player1)]
        public void FindCorrectWinnerAfterThreeRoundsWithDraws(int player1Score, int player2Score, int draws, GameWinner expectedWinner)
        {
            var game = new Game
            {
                Player1Wins = player1Score,
                Player2Wins = player2Score,
                Draws = draws
            };
            game.GetWinner().Should().Be(expectedWinner);
        }

        [Test]
        public void GameWithoutRoundsShouldBeUndecided()
        {
            var game = new Game();
            game.GetWinner().Should().Be(GameWinner.Undecided);
        }
    }
}
