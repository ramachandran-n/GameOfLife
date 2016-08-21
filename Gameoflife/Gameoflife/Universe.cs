using GameOfLife;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Universe
    {
        private int maxColumns;
        private int maxRows;
        private  Cell[,] _cell;
        private Cell[,] _newGeneration;
        public Universe(int rows, int columns)
        {
            this.maxRows = rows;
            this.maxColumns = columns;
           this._cell = new Cell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _cell[i,j] = new Cell(false);
                }
            }
        }

        public Universe(int rows,int columns,Cell[,] cells)
        {
            this.maxRows = rows;
            this.maxColumns = columns;
            this._cell = cells;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    builder.Append(_cell[i, j].IsAlive()?"x":"-").Append(" ");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }

        public int CountLiveNeighbours(int row, int column)
        {
            int count = default(int);
            //passing 0,0 -> i=-1 ;i <= 1 ;i++ - false
            // i=0; i<=1; i++ -> j= -1 ; j<=1;j++ - false
            // i=0; i<=1; i++ -> j= 0 ; j<=1 ;j++ -> i=0 and row 0 , j=0 and column =0 - false
            // i=0; i<=1; i++ -> j= 1 ; j<=1 ;j++ -> i=0 and row 0 , j=1 and column =0 - true - count =1
            // i=0; i<=1; i++ -> j= 2 ; j<=1 ;j++ -> false
            // i=1; i<=1; i++ -> j= -1 ; j<=1 ;j++ -> false
            // i=1; i<=1; i++ -> j= 0 ; j<=1 ;j++ -> j>=0 and j<2 -> i =1 and row = 0, j= 0 and column =0  -> count =2
            // i=1; i<=1; i++ -> j= 1 ; j<=1 ;j++ -> j>=1 and j<2 -> i =1 and row = 0, j= 1 and column =0  -> count =3
            for (int i = row-1; i <= row+1; i++)
            {
                if (i >= 0 && i < maxRows)
                for (int j = column-1; j <= maxColumns+1; j++)
                    {
                        if(j>=0 && j < maxColumns)
                        if (!(i == row && j == column))
                            count += _cell[i, j].IsAlive() ? 1 : 0;
                    }
            }
            return count;
        }

        public Universe EnforceRules()
        {
            Rules rule = new Rules();
            _newGeneration = new Cell[maxRows,maxColumns];
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    _cell[i, j] = rule.OverPopulation(_cell[i, j], CountLiveNeighbours(i, j));
                    _cell[i, j] = rule.UnderPopulation(_cell[i, j], CountLiveNeighbours(i, j));
                    _cell[i, j] = rule.Exactlt3Neighbour(_cell[i, j], CountLiveNeighbours(i, j));
                    _newGeneration[i, j] = _cell[i, j];
                }
            }
            return new Universe(maxRows,maxColumns,_newGeneration);
        }

        public void seed(string[,] strings)
        {
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    this._cell[i,j] = new Cell(strings[i,j]);
                }
            }
        }
    }
}
