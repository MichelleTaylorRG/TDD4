using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TDD4
{
    [TestFixture]
    public class RoundWinnerTests
    {
        [Test]
        public void RockBluntsScissors()
        {
            Round.Wins(Selection.Rock, Selection.Scissors).Should().Be(RoundResult.Player1Win);
        }

        [Test]
        public void ScissorsCutsPaper()
        {
            Round.Wins(Selection.Scissors, Selection.Paper).Should().Be(RoundResult.Player1Win);
        }

        [Test]
        public void PaperWrapsRock()
        {
            Round.Wins(Selection.Rock, Selection.Paper).Should().Be(RoundResult.Player2Win);
        }

        [Test]
        public void RoundDrawOnBothSelectingRock()
        {
            Round.Wins(Selection.Rock, Selection.Rock).Should().Be(RoundResult.Draw);
        }
    }
}
