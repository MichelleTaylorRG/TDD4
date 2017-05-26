using System.Collections.Generic;
using System.Linq;

namespace TDD4
{
    public class Game
    {
        public int Player1Wins { get; set; }

        public int Player2Wins { get; set; }

        public int Draws { get; set; }

        public GameWinner GetWinner()
        {
            if (Player1Wins + Player2Wins + Draws  < 3)
            {
                return GameWinner.Undecided;
            }

            if (Player1Wins == Player2Wins)
            {
                return GameWinner.Undecided;
            }

            return Player1Wins > Player2Wins ? GameWinner.Player1 : GameWinner.Player2;
        }
    }
}