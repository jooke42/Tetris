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

        public override bool Equals(Object obj)
        {
            return obj is Position && this == (Position)obj;
        }

        public override int GetHashCode()
        {
            return row.GetHashCode() ^ col.GetHashCode();
        }

        public static bool operator ==(Position x, Position y)
        {
            return x.col== y.col && x.row == y.row;
        }
        public static bool operator !=(Position x, Position y)
        {
            return !(x == y);
        }
        public static Position operator +(Position x, Position y)
        {
            return new Position(x.row + y.row, x.col + y.col);
        }
        public static Position operator -(Position x, Position y)
        {
            return new Position(x.row - y.row, x.col -y.col);
        }
    }
    class MovableGrid : Grid
    {
        public Grid tetromino;
        public Position position;

        public MovableGrid(Grid _tetromino)
        {
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

        public bool canMoveTo(Board board, Position offset)
        {
            Position nextPosition = this.position + offset;

            for (int r = 0; r < this.tetromino.Rows(); r++)
            {
                for (int c = 0; c < this.tetromino.Columns(); c++)
                {
                    if (r + nextPosition.row >= board.Rows() || r + nextPosition.row <0)
                        return false;

                    if (c + nextPosition.col >= board.Columns() || c + nextPosition.col <0)
                        return false;

                    if (this.tetromino.CellAt(r, c) != '.' && board.CellAt(nextPosition.row  + r,nextPosition.col + c) != '.')
                        return false;
                }
            }
            return true;
        }

        public int Rows()
        {
            return tetromino.Rows();
        }

        public int Columns()
        {
            return tetromino.Columns();
        }

        public char CellAt(int row, int col)
        {
            return tetromino.CellAt(row, col);
        }

        public int toRowShape(int boardRow)
        {
            return boardRow - this.position.row;
        }

        public int toColShape(int boardCol)
        {
            return boardCol - this.position.col;
        }

        //check if coord board is inGrid of shape
        public bool CurrentPieceInGrid(int shapeRow, int shapeCol)
        {
            return (shapeCol >= 0 && shapeCol < this.Columns()) && (shapeRow >= 0 && shapeRow < this.Rows());
        }
    }
    

}
