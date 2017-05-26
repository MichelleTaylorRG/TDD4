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
    public class RockPaperScissorsTests
    {
        [Test]
        public void RockBluntsScissors()
        {
            Round.Wins(Selection.Rock, Selection.Scissors).Should().Be(Selection.Rock);
        }

        [Test]
        public void ScissorsCutsPaper()
        {
            Round.Wins(Selection.Scissors, Selection.Paper).Should().Be(Selection.Scissors);
        }
    }


}
