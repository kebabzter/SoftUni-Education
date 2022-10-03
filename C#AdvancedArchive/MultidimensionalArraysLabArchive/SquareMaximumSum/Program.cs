using System;
using System.Linq;

namespace SquareMaximumSum
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
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = current[c];
                }
            }
            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int r = 0; r < rows-1; r++)
            {
                for (int c = 0; c < cols-1; c++)
                {
                    int currentSum = matrix[r, c] + matrix[r, c + 1] + matrix[r + 1, c] + matrix[r + 1, c + 1];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = r;
                        maxCol = c;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1,maxCol+1]}");
            Console.WriteLine(maxSum);
        }
    }
}
