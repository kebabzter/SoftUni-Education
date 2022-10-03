using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            int primary = 0;
            int secondary = 0;
            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                primary += matrix[row, row];
                secondary += matrix[row,n-row-1];
            }
            
            Console.WriteLine(Math.Abs(primary-secondary));
        }
    }
}
