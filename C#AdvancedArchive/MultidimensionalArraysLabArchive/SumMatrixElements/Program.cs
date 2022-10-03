using System;
using System.Linq;

namespace SumMatrixElements
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
            int[,] matrix = new int[rows,cols];
            int sum = 0;

            for (int r = 0; r < rows; r++)
            {
                int[] current = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = current[c];
                    sum += matrix[r,c];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
