﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class UniverseTests
    {
        [Test]
        public void ShouldCreateDeadUniverse()
        {
            Universe universe = new Universe(2,2);
            string sut = universe.ToString();
            Assert.That(sut,Is.EqualTo(("- - \n- - \n")));
        }

        [Test]
        public void ShouldSeedUniverse()
        {
            Universe universe = new Universe(2, 2);
            universe.seed(new string[,] { {"x","x"}, {"x","x"} });
            string sut = universe.ToString();
            Assert.That(sut, Is.EqualTo(("x x \nx x \n")));
        }

        [Test]
        public void ShouldCountNeighbours()
        {
            Universe universe = new Universe(2,2);
            universe.seed(new string[,] { { "x", "x" }, { "x", "x" } });
            int neighbourCount = universe.CountLiveNeighbours(1, 1);
            Assert.That(neighbourCount,Is.EqualTo(3));
        }

        [Test]
        public void ShouldApplyRulesAllAlive()
        {
            Universe universe = new Universe(2, 2);
            universe.seed(new string[,] { { "x", "x" }, { "x", "x" } });
            universe = universe.EnforceRules();
            Assert.That(universe.ToString(), Is.EqualTo(("x x \nx x \n")));
        }

        [Test]
        public void ShouldApplyRulesOnly2ALive()
        {
            Universe universe = new Universe(2, 2);
            universe.seed(new string[,] { { "x", "-" }, { "x", "-" } });
            universe = universe.EnforceRules();
            Assert.That(universe.ToString(), Is.EqualTo(("- - \n- - \n")));
        }
        [Test]
        public void ShouldApplyRulesOnlyBeALive()
        {
            Universe universe = new Universe(2, 2);
            universe.seed(new string[,] { { "x", "x" }, { "x", "-" } });
            universe = universe.EnforceRules();
            Assert.That(universe.ToString(), Is.EqualTo(("x x \nx x \n")));
        }

        [Test]
        public void ShouldApplyRulesAllDead()
        {
            Universe universe = new Universe(2, 2);
            universe.seed(new string[,] { { "x", "-" }, { "-", "-" } });
            universe = universe.EnforceRules();
            Assert.That(universe.ToString(), Is.EqualTo(("- - \n- - \n")));
        }

    }
}
