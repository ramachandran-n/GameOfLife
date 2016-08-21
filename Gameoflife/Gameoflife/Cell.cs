using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        private bool Alive;

        public Cell(bool state)
        {
            this.Alive = state;
        }

        public Cell(string value)
        {
            this.Alive = value.Equals("X", StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsAlive()
        {
            return Alive;
        }

        public Cell Kill()
        {
            return new Cell(false);
        }

        public override string ToString()
        {
            return IsAlive() ? "x" : "-";
        }
    }
}
