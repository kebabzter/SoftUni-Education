using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArrayFromConsole();
            int[,] matrix = new int[size[0], size[1]];
            
            for (int row = 0; row < size[0]; row++)
            {
                int[] currentRow = ReadArrayFromConsole();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row,col];
                }
                Console.WriteLine(sum);
            }            
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new string[] { ", "," " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
