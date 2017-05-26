namespace TDD4
{
    public class Game
    {
        public int Player1Score { get; set; }

        public GameWinner GetWinner()
        {
            return GameWinner.Player1;
        }
    }
}