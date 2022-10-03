using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                int[] current = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = current[c];
                    if (r==c)
                    {
                        sum += matrix[r,c];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
