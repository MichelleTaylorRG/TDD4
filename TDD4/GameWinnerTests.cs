﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TDD4
{
    [TestFixture]
    class GameWinnerTests
    {
        [Test]
        public void ThreeWonRoundsWinGameForPlayerOne()
        {
            var game = new Game {Player1Score = 3};
            game.GetWinner().Should().Be(GameWinner.Player1);
        }
    }
}