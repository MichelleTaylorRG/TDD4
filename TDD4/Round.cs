using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD4
{
    public class Round
    {
        public static Selection Wins(Selection player1Selection, Selection player2Selection)
        {
            switch (player1Selection)
            {
                    case Selection.Rock:
                    switch (player2Selection)
                    {
                        case Selection.Scissors:
                            return Selection.Rock;
                        case Selection.Paper:
                            return Selection.Paper;
                    }
                    break;
                    case Selection.Paper:
                    switch (player2Selection)
                    {
                        case Selection.Scissors:
                            return Selection.Scissors;
                        case Selection.Rock:
                            return Selection.Paper;
                    }
                    break;
                    case Selection.Scissors:
                    switch (player2Selection)
                    {
                        case Selection.Rock:
                            return Selection.Rock;
                        case Selection.Paper:
                            return Selection.Scissors;
                    }
                    break;
            }

            return player1Selection;
        }
    }
}
