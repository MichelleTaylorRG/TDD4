using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Terrible RPS!");

            var game = new Game();
            do
            {
                Console.WriteLine(" Player 2, look away! Player one, R, P or S?");
                var input1 = Console.ReadKey().KeyChar.ToString();
                Console.Clear();
                Console.WriteLine("Okay player one look away, player 2, R, P or S?");
                var input2 = Console.ReadKey().KeyChar.ToString();
                Console.Clear();

                var round = new Round();

                round.InputPlayerOneSelection(input1);
                round.InputPlayerTwoSelection(input2);

                var roundResult = Round.Wins(round.PlayerOneSelection, round.PlayerTwoSelection);

                switch (roundResult)
                {
                    case RoundResult.Draw:
                        game.Draws++;
                        break;
                    case RoundResult.Player1Win:
                        game.Player1Wins++;
                        break;
                    case RoundResult.Player2Win:
                        game.Player2Wins++;
                        break;
                }
            } while (game.GetWinner() == GameWinner.Undecided);

            Console.WriteLine("Congratulations " + game.GetWinner());
        }
    }
}
