using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArrayFromConsole();
            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;
            for (int row = 0; row < size[0]; row++)
            {
                int[] currentRow=ReadArrayFromConsole();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                    sum += matrix[row,col];
                }
            }

            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            Console.WriteLine(sum);
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
