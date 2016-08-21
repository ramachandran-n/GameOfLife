using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void ShouldReturnCellAlive()
        {
            Cell cell = new Cell(true);
            Assert.That(cell.IsAlive().Equals(true));
        }
        [Test]
        public void ShouldReturnCellDead()
        {
            Cell cell = new Cell(false);
            Assert.That((cell.IsAlive().Equals(false)));
        }

        [Test]
        public void ShouldKillCell()
        {
            Cell cell = new Cell(true);
            cell.Kill();
        }
    }
}
