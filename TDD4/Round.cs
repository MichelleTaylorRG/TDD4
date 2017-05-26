using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD4
{
    public class Round
    {
        public Selection PlayerOneSelection;

        public void InputPlayerOneSelection(string userInput)
        {
            switch (userInput)
            {
                case "R":
                    PlayerOneSelection = Selection.Rock;
                    break;
                case "S":
                    PlayerOneSelection = Selection.Scissors;
                    break;
                case "P":
                    PlayerOneSelection = Selection.Paper;
                    break;
            }
            throw new Exception("I ran out of time to do input errors politely");
        }

        public Selection PlayerTwoSelection;

        public void InputPlayerTwoSelection(string userInput)
        {
            switch (userInput)
            {
                case "R":
                    PlayerTwoSelection = Selection.Rock;
                    break;
                case "S":
                    PlayerTwoSelection = Selection.Scissors;
                    break;
                case "P":
                    PlayerTwoSelection = Selection.Paper;
                    break;
            }
            throw new Exception("I ran out of time to do input errors politely");
        }

        public static RoundResult Wins(Selection player1Selection, Selection player2Selection)
        {
            if (player1Selection == player2Selection) return RoundResult.Draw;

            switch (player1Selection)
            {
                    case Selection.Rock:
                    switch (player2Selection)
                    {
                        case Selection.Scissors:
                            return RoundResult.Player1Win;
                        case Selection.Paper:
                            return RoundResult.Player2Win;                       
                    }
                    break;
                    case Selection.Paper:
                    switch (player2Selection)
                    {
                        case Selection.Scissors:
                            return RoundResult.Player2Win;
                        case Selection.Rock:
                            return RoundResult.Player1Win;
                    }
                    break;
                    case Selection.Scissors:
                    switch (player2Selection)
                    {
                        case Selection.Rock:
                            return RoundResult.Player2Win;
                        case Selection.Paper:
                            return RoundResult.Player1Win;
                    }
                    break;
            }
            throw new ArgumentException($"Didn't recognise selection combination: {player1Selection} {player2Selection}");
        }
    }
}
