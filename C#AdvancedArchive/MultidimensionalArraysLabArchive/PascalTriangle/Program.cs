using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];
            jagged[0] = new long[] { 1 };
            for (int i = 1; i < n; i++)
            {
                long[] current = new long[i + 1];
                for (int j = 0; j < i + 1; j++)
                {
                    if (j - 1 < 0 || (j == i))
                    {
                        current[j] = 1;
                    }
                    else
                    {
                        current[j] = jagged[i - 1][j] + jagged[i - 1][j - 1];
                    }
                }
                jagged[i] = current;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
