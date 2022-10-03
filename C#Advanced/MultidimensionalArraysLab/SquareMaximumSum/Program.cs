using System;
using System.Linq;

namespace SquareMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArrayFromConsole();
            int[,] matrix = new int[size[0], size[1]];
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int currentSum = matrix[row,col]+matrix[row,col+1]+ matrix[row+1, col] + matrix[row+1, col+1];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1,maxCol+1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
