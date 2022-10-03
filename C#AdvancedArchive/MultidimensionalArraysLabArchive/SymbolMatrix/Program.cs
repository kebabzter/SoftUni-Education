using System;

namespace SymbolMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            for (int r = 0; r < n; r++)
            {
                char[] current = Console.ReadLine()
                    .ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = current[c];
                }
            }
            bool flag = false;
            char symbol = char.Parse(Console.ReadLine());
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r,c]==symbol)
                    {
                        flag = true;
                        Console.WriteLine($"({r}, {c})");
                        return;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
