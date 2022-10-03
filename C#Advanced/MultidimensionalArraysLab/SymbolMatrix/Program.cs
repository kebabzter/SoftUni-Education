using System;
using System.Linq;

namespace SymbolMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            bool flag = true;
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbol == matrix[row,col])
                    {
                        flag = false;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
