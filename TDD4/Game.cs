using System.Collections.Generic;
using System.Linq;

namespace TDD4
{
    public class Game
    {
        public List<RoundResult> roundResults = new List<RoundResult>();

        public GameWinner GetWinner()
        {
            if (roundResults.Count < 3)
            {
                return GameWinner.Undecided;
            }

            var player1Wins = roundResults.Count(x => x == RoundResult.Player1Win);
            var player2Wins = roundResults.Count(x => x == RoundResult.Player2Win);

            if (player1Wins > player2Wins)
            {
                return GameWinner.Player1;
            }

            return GameWinner.Player2;
        }
    }
}