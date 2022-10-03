using System;
using System.Linq;

namespace SquaresMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = rowCol[0];
            int columns = rowCol[1];
            char[,] matrix = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                char[] current = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = current[j];
                }
            }
            int count = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
