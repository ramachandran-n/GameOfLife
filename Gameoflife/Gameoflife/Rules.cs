using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Rules
    {
        public Cell OverPopulation(Cell cell, int neighbourCount)
        {
            if (neighbourCount > 3)
            {
                return new Cell(false);
            }
            return cell;
        }
        public Cell UnderPopulation(Cell cell, int neighbourCount)
        {
            if (neighbourCount < 2)
            {
                return new Cell(false);
            }
            return cell;
        }

        public Cell Exactlt3Neighbour(Cell cell, int neighbourCount)
        {
            if (neighbourCount == 3)
            {
                return new Cell(true);
            }
            return cell;
        }
    }
}
