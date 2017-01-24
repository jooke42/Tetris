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
        StringToMatrix sToM;
        public Piece(string blockraw)
        {
            sToM = new StringToMatrix(blockraw);
        }
        public char CellAt(int row, int col)
        {
            return sToM.blocks[row,col];
        }

        public int Columns()
        {
            return sToM.blocks.GetLength(1);
        }

        public int Rows()
        {
            return sToM.blocks.GetLength(0);
        }

        
        public override string ToString()
        {
            return sToM.ToString();
        }
    }
}
