using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public struct Position
    {
        public int col, row;
        public Position(int _row,int _col)
        {
            col = _col;
            row = _row;
        }
    }
    class MovableGrid
    {
        public Grid tetromino;
        public Position position;
        public bool isfalling;
        public MovableGrid(Grid _tetromino, bool isfalling = true)
        {
            this.isfalling = isfalling;
            this.tetromino = _tetromino;
        }

        public Position getPosition()
        {
            return position;
        }

        public void SetPosition(int _row, int _col)
        {
            position.col = _col;
            position.row = _row;
        }

        public bool CanFall(char[][] board)
        {
            
                for (int r = 0; r < this.tetromino.Rows(); r++)
                {
                    for (int c = 0; c < this.tetromino.Columns(); c++)
                    {
                    if (this.tetromino.CellAt(r, c) != '.' && board[this.position.row + r + 1][this.position.col + c] != '.')
                        return false;
                    if (this.position.row + r + 1 >= board.Length)
                        return false;
   
                    }
                }
            return true;
            }
        }
    public bool InGrid(int row, int col)
    {
        return 
    }

}
