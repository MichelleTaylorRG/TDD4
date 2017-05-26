namespace TDD4
{
    public class Game
    {
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public GameWinner GetWinner()
        {
            if (Player2Score == 3) return GameWinner.Player2;
            return GameWinner.Player1;
        }
    }
}