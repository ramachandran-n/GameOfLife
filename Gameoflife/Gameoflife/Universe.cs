using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameoflife
{
    public class Universe
    {
        public int  maxRows{ get; private set; }
        public int  maxCols{ get; private set; }

        private Cell[,] cells;
        public Universe(int rowCount, int colCount)
        {
            maxRows = rowCount;
            maxCols = colCount;
            InitializeUniverse();
        }
        private void InitializeUniverse()
        {
            cells.Fill(new Cell(true));
        }

        int CountAliveCells(int row, int column)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i >= 0 && i < this.maxRows)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (j >= 0 && j < this.maxCols)
                        {
                            if (!(i == row && j == column))
                            {
                                if (this.cells[i,j].IsAlive())
                                    count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
}
