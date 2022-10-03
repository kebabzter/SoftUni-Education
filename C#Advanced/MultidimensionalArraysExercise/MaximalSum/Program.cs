using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = ReadMatrix(rows,cols);
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int firstRow = matrix[row, col]+matrix[row,col+1]+matrix[row,col+2];
                    int secondRow = matrix[row+1, col]+matrix[row+1,col+1]+matrix[row+1,col+2];
                    int thirdRow = matrix[row+2, col]+matrix[row+2,col+1]+matrix[row+2,col+2];
                    int currentSum = firstRow+secondRow+thirdRow;
                    if (currentSum>maxSum)
                    {
                        maxSum=currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{matrix[maxRow+row,maxCol+col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
        }
    }
}
