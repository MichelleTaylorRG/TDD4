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
        private IList<RoundResult> generateRounds(int player1Score, int player2Score, int draws)
        {
            var roundResults = new List<RoundResult>();

            var player1WinsGenerated = 0;
            var player2WinsGenerated = 0;
            var drawsGenerated = 0;
            var randomGenerator = new Random();
            for (var i = 0; i < player1Score + player2Score + draws; i++)
            {
                if (player1Score > player1WinsGenerated)
                {
                    if (player2Score > player2WinsGenerated)
                    {
                        if (draws > drawsGenerated)
                        {
                            var randomSelection = randomGenerator.Next(2);
                            switch (randomSelection)
                            {
                                case 0:
                                    roundResults.Add(RoundResult.Draw);
                                    drawsGenerated++;
                                    break;
                                case 1:
                                    roundResults.Add(RoundResult.Player1Win);
                                    player1WinsGenerated++;
                                    break;
                                case 2:
                                    roundResults.Add(RoundResult.Player2Win);
                                    player2WinsGenerated++;
                                    break;
                            }
                        }
                        else
                        {
                            var randomSelection = randomGenerator.Next(1);
                            switch (randomSelection)
                            {
                                case 1:
                                    roundResults.Add(RoundResult.Player1Win);
                                    player1WinsGenerated++;
                                    break;
                                case 2:
                                    roundResults.Add(RoundResult.Player2Win);
                                    player2WinsGenerated++;
                                    break;
                            }
                        }
                    }
                    roundResults.Add(RoundResult.Player1Win);
                    player1WinsGenerated++;
                }
                else if (player2Score > player2WinsGenerated)
                {
                    if (draws < drawsGenerated)
                    {
                        var randomSelection = randomGenerator.Next(1);
                        switch (randomSelection)
                        {
                            case 0:
                                roundResults.Add(RoundResult.Draw);
                                drawsGenerated++;
                                break;
                            case 1:
                                roundResults.Add(RoundResult.Player2Win);
                                player2WinsGenerated++;
                                break;
                        }
                    }
                    else
                    {
                        roundResults.Add(RoundResult.Player2Win);
                        player2WinsGenerated++;
                    }
                    throw new Exception("I ran out of things to generate before I ran out of rounds!");
                }
                else if (draws > drawsGenerated)
                {
                    roundResults.Add(RoundResult.Draw);
                    drawsGenerated++;
                }
            }
            return roundResults;            
        }


        [TestCase(0, 3, GameWinner.Player2)]
        [TestCase(3, 0, GameWinner.Player1)]
        public void ThreeWonRoundsWinGame(int player1Score, int player2Score, GameWinner expectedWinner)
        {
            var game = new Game();
            game.roundResults.AddRange(generateRounds(player1Score,player2Score,0));
            game.GetWinner().Should().Be(expectedWinner);
        }
        
        [TestCase(0, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 2)]
        [TestCase(1, 1)]
        public void LessThanThreeWonRoundsShouldBeUndecided(int player1Score, int player2Score)
        {
            var game = new Game();
            game.roundResults.AddRange(generateRounds(player1Score, player2Score, 0));
            game.GetWinner().Should().Be(GameWinner.Undecided);
        }

        [TestCase(1, 2, GameWinner.Player2)]
        [TestCase(2, 1, GameWinner.Player1)]
        public void ClearWinnerAfterThreeRoundsShouldWin(int player1Score, int player2Score, GameWinner expectedWinner)
        {
            var game = new Game();
            game.roundResults.AddRange(generateRounds(player1Score, player2Score, 0));
            game.GetWinner().Should().Be(expectedWinner);
        }
    }
}
