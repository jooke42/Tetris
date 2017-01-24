using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    
    public interface Grid
    {
        int Rows();
        int Columns();
        char CellAt(int row, int col);
    }

    public class Piece : Grid
    {
        private int offsetRow;
        char[,] grid;
        public Piece(string blockraw)
        {
            grid = StringToMatrix.toMatrix(blockraw);
        }
        public char CellAt(int row, int col)
        {
            return grid[row, col];
        }

        public int Columns()
        {
            return grid.GetLength(1);
        }

        public int Rows()
        {
            return grid.GetLength(0);
        }

        

        public override string ToString()
        {
            return StringToMatrix.Inverse(grid,Rows(),Columns());
        }
    }
}
