using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TDD4
{
    [TestFixture]
    public class PlayerSelectionTests
    {
        [TestCase("R", Selection.Rock)]
        [TestCase("S", Selection.Scissors)]
        [TestCase("P", Selection.Paper)]
        public void PlayerOneCanInputSelection(string input, Selection expectedSelection)
        {
            var round = new Round();
            round.InputPlayerOneSelection(input);
            round.PlayerOneSelection.Should().Be(expectedSelection);
        }

        [TestCase("gibberish")]
        public void PlayerOneCanInputSelection(string input)
        {
            var round = new Round();
            Assert.Throws<Exception>(() => round.InputPlayerOneSelection(input));           
        }
    }
}
