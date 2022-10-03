using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = firstLine[0];
            int cols = firstLine[1];

            int[,] matrix = new int[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Bloom Bloom Plow")
                {
                    break;
                }
                int[] currentLine = input
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
                int rowPosition = currentLine[0];
                int colPosition = currentLine[1];

                if (!isValidCell(rowPosition,colPosition,rows,cols))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < rows; i++)
                {
                    matrix[i, colPosition] += 1;
                }

                for (int i = 0; i < cols; i++)
                {
                    if (i!=rowPosition)
                    {
                        matrix[rowPosition, i] += 1;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }

        }

        private static bool isValidCell(int r, int c, int rows, int cols)
        {
            return r >= 0 && r < rows && c >= 0 && c < cols;
        }

    }
}
