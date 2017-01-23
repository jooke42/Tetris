using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        readonly int rows;
        readonly int columns;
        Char[][] board;
        MovableGrid currentPiece = null;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new  char[rows][];
            for(int i=0;i< rows;i++)
            {
                board[i] = new char[columns];
                for (int j = 0; j < columns; j++)
                {
                    board[i][j] = '.';
                }
            }
        }

        public override String ToString()
        {
            String s = "";
            int row = 0, col = 0;
            while (row < rows)
            {
                while (col < columns)
                {
                    if(currentPiece.position.row == row && currentPiece.position.col == col)
                    {
                        s += currentPiece.tetromino.CellAt(row + StartingRowOffset(currentPiece.tetromino), 0);
                       
                    }
                    else
                    {
                        s += board[row][col];
                    }
                    


                    col++;
                }
                s += "\n";
                row++;
            }
            return s;
        }
        public void Drop(Grid block)
        {
            if (IsFallingBlock() == false)
            {
                currentPiece = new MovableGrid(block);
                currentPiece.SetPosition(StartingRowOffset(currentPiece.tetromino), this.columns / 2 - currentPiece.tetromino.Columns() / 2);
                
            }else
            {
                throw new ArgumentException("A block is already falling.");
            }  
        }

        public bool IsFallingBlock()
        {
            return currentPiece!=null && currentPiece.isfalling;
        }

        public void Tick()
        {
            if (!currentPiece.CanFall(this.board))
                  currentPiece.isfalling = false;
            if (currentPiece.isfalling)
                currentPiece.SetPosition(currentPiece.getPosition().row + 1, currentPiece.getPosition().col);
            
        }
        void movedown(Position x)
        {
            board[x.row + 1][x.col] = board[x.row][x.col];
            board[x.row][x.col] = '.';
        }
        static int StartingRowOffset(Grid shape)
        {
            for (int r = 0; r < shape.Rows(); r++)
            {
                for (int c = 0; c < shape.Columns(); c++)
                {
                    if (shape.CellAt(r, c) != '.') return -r;
                }
            } 
            return 0;
        }
    }

}
