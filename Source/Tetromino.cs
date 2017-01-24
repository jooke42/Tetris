using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {
        int currentRotation = 0;
        private Piece[] pieces;

        public static Tetromino T_SHAPE = new Tetromino(0,
                "....\n" +
                "TTT.\n" +
                ".T..\n"
            ,
                ".T..\n" +
                "TT..\n" +
                ".T..\n"
            ,
                "....\n" +
                ".T..\n" +
                "TTT.\n"
            ,
                ".T..\n" +
                ".TT.\n" +
                ".T..\n"
            );

        public Tetromino(int _currentRotation, params string[] orientations)
        {
            this.pieces = new Piece[orientations.Length];
            this.currentRotation = mod(_currentRotation, orientations.Length);

            for (int i = 0; i < orientations.Length; i++)
            {
                this.pieces[i] = new Piece(orientations[i]);
            }
        }

        public Tetromino(int _currentRotation, Piece[] _rotations)
        {
            pieces = _rotations;
            currentRotation = _currentRotation;
        }


        public Tetromino RotateRight()
        {
            return new Tetromino((currentRotation + 1) % pieces.Length,this.pieces);
        }

        public Tetromino RotateLeft()
        {
            return new Tetromino((currentRotation + -1 + pieces.Length) % pieces.Length, this.pieces);
        }

        private int mod(int a, int n)
        {
            int result = a % n;

            if ((a < 0 && n > 0) || (a < 0 && n < 0))
                result += n;

            return result;
        }

        public int Rows()
        {
            return pieces[currentRotation].Rows();
        }

        public int Columns()
        {
            return pieces[currentRotation].Columns();
        }

        public char CellAt(int row, int col)
        {
            return pieces[currentRotation].CellAt(row,col);
        }


        public override string ToString()
        {
            return pieces[currentRotation].ToString();
        }

    }
}
