using System;
using System.Linq;

namespace MatrixPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int row = size[0];
            int col = size[1];
            string[,] matrix= new string[row,col];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    string str = string.Empty;
                    str = alphabet[r].ToString();
                    str += alphabet[r + c].ToString();
                    str += alphabet[r].ToString();
                    matrix[r, c] = str;
                }
            }

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write($"{matrix[r,c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
