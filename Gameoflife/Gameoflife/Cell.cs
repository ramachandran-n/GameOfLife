using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameoflife
{
    /// <summary>
    /// Represents a single cell in the universe
    /// </summary>
    public class Cell
    {
        private bool isAlive;
        public Cell(bool alive)
        {
            this.isAlive = alive;
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public Cell Kill()
        {
            return new Cell(false);
        }

        public Cell Live()
        {
            return new Cell(true);
        }
    }
}
