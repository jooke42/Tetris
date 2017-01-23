using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source { 

    public class StringToMatrix
    {
        public char[,] blocks;
        public StringToMatrix(String blocksraw)
        {
            String[] lines = blocksraw.Split('\n');
            blocks= new char[lines.Length-1, lines[0].Length];
            int row = 0, col = 0;
            foreach(string line in lines)
            {
                col = 0;
                foreach(char charac in line.ToCharArray())
                {
                    blocks[row,col] = charac;
                    col++;
                }
                
                row++;

            }
        }

        public static string Inverse(char[,] matrix, int v1, int v2)
        {

            String s = "";
            for (int row = 0; row < v1; row++)
            {
                for (int col = 0; col < v2; col++)
                {
                    s += matrix[row,col];
                }
                s += "\n";
            }

            return s;
           
        }
    }
}
