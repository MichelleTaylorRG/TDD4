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
        public void RockBeatsScissors()
        {
            Round.Wins(Selection.Rock, Selection.Scissors).Should().Be(Selection.Rock);
        }

    }


}
