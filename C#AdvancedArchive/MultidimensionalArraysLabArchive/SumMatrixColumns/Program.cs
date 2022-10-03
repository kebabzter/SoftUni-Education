using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            
            for (int r = 0; r < rows; r++)
            {
                int[] current = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = current[c];
                }
            }

            for (int c = 0; c < cols; c++)
            {
                int sum = 0;
                for (int r = 0; r < rows; r++)
                {
                    sum += matrix[r,c];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
