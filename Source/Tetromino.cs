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
        String[] rotations;
        public Piece[] pieces;

        public static Tetromino T_SHAPE = new Tetromino(0, 
                "....\n" +
                "TTT.\n" +
                ".T..\n"
            );

        public Tetromino(String rotation1, String rotation2, String  rotation3 , String rotation4)
        {
            rotations = new string[]{ rotation1, rotation2, rotation3, rotation4};
        }

        public Tetromino(Piece[] _pieces)
        {
            this.pieces = _pieces;
        }

        // unknown number of string parameters for orientations
        public Tetromino(int _currentRotation, params string[] orientations)
        {
            this.pieces = new Piece[orientations.Length];
            this.currentRotation = mod(_currentRotation, orientations.Length);

            for (int i = 0; i < orientations.Length; i++)
            {
                this.pieces[i] = new Piece(orientations[i]);
            }
        }

        /*public Tetromino(int _currentRotation, string[] _rotations)
        {
            rotations = _rotations;
            currentRotation = _currentRotation;
        }*/

        public override string ToString()
        {
            return rotations[currentRotation];
        }

        public Tetromino RotateRight()
        {
            return new Tetromino((currentRotation + 1) % rotations.Length,this.rotations);
        }

        public Tetromino RotateLeft()
        {
            return new Tetromino((currentRotation + -1 + rotations.Length) % rotations.Length, this.rotations);
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
            return pieces.GetLength(0);
        }

        public int Columns()
        {
            return pieces.GetLength(1);
        }

        public char CellAt(int row, int col)
        {
            return 'A';
            // TODO
        }
    }
}
