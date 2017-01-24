using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board : Grid
    {
        readonly int rows;
        readonly int columns;
        Char[,] board;
        MovableGrid currentPiece = null;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new char[rows, columns];

            for(int i=0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '.';
                }
            }
        }

        public void MoveDown()
        {
            if (currentPiece != null && currentPiece.canMoveTo(this,new Position(1,0)))
                currentPiece.position.row++;
        }
        public void MoveLeft()
        {
            if (currentPiece != null && currentPiece.canMoveTo(this, new Position(0, -1)))
                currentPiece.position.col--;
        }

        

        public void Drop(Grid block)
        {
            if (IsFallingBlock() == false)
            {
                currentPiece = new MovableGrid(block);
                currentPiece.SetPosition(StartingRowOffset(currentPiece.tetromino), this.columns / 2 - currentPiece.tetromino.Columns() / 2);
            } else
            {
                throw new ArgumentException("A block is already falling.");
            }  
        }

        public bool IsFallingBlock()
        {
            return currentPiece!=null ;
        }

        public void Tick()
        {
            if (currentPiece.canMoveTo(this,new Position(1,0)) == false)
            {
                addCurrentShapeToBoard();
                currentPiece = null;
            }
            if (IsFallingBlock())
                MoveDown();            
        }
        

        private void addCurrentShapeToBoard()
        {
            for (int r = 0; r < currentPiece.Rows(); r++)
            {
                for (int c = 0; c < currentPiece.Columns(); c++)
                {
                    if (currentPiece.CellAt(r, c) != '.')
                        board[currentPiece.position.row + r,currentPiece.position.col + c] = currentPiece.CellAt(r, c);
                }
            }
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

        public void FromString(string v)
        {
            throw new NotImplementedException();
        }

        public int Rows()
        {
            return this.rows;
        }

        public int Columns()
        {
            return this.columns;
        }

        public char CellAt(int row, int col)
        {
            return board[row, col];
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (currentPiece != null)
                    {
                        int rowShape = currentPiece.toRowShape(row);
                        int colShape = currentPiece.toColShape(col);
                        if (currentPiece.CurrentPieceInGrid(rowShape, colShape))
                        {
                            s += currentPiece.tetromino.CellAt(rowShape, colShape);


                        }
                        else
                        {
                            s += board[row,col];
                        }
                    }
                    else
                    {
                        s += board[row,col];
                    }
                }
                s += "\n";
            }
            return s;
        }

        
    }

}
