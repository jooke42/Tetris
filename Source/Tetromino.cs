using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino
    {
        int currentRotation = 0;
        String[] rotations;
        public static Grid T_SHAPE = new Piece(
                "....\n" +
                "TTT.\n" +
                ".T..\n"
            );

        public Tetromino(String rotation1, String rotation2, String  rotation3 , String rotation4)
        {
         
            rotations = new string[]{ rotation1, rotation2, rotation3, rotation4};

        }

        public Tetromino(int _currentRotation, string[] _rotations)
        {

            rotations = _rotations;
            currentRotation = _currentRotation;

        }

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
    }
}
