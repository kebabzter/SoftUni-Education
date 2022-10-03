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
            int sumDLeft = 0;
            int sumDRight = 0;
            for (int r = 0; r < n; r++)
            {
                int[] current = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = current[c];
                }
            }

            for (int i = 0; i < n; i++)
            {
                sumDLeft += matrix[i, i];
                sumDRight += matrix[i, n - i - 1];
            }
            Console.WriteLine(Math.Abs(sumDLeft - sumDRight));
        }
    }
}
