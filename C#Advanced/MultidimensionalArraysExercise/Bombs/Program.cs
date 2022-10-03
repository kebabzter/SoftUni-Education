using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = ReadArray();
            }

            string[] arr = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                int[] coordinates = arr[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentRow = coordinates[0];
                int currentCol = coordinates[1];

                if (jagged[currentRow][currentCol] <= 0)
                {
                    continue;
                }
                int valueBomb = jagged[currentRow][currentCol];
                jagged[currentRow][currentCol] = 0;

                if (isValidIndex(currentRow - 1, currentCol - 1, jagged.Length) && jagged[currentRow - 1][currentCol - 1] > 0)
                {
                    jagged[currentRow - 1][currentCol - 1] -= valueBomb;
                }

                if (isValidIndex(currentRow - 1, currentCol, jagged.Length) && jagged[currentRow - 1][currentCol] > 0)
                {
                    jagged[currentRow - 1][currentCol] -= valueBomb;
                }

                if (isValidIndex(currentRow - 1, currentCol + 1, jagged.Length) && jagged[currentRow - 1][currentCol + 1] > 0)
                {
                    jagged[currentRow - 1][currentCol + 1] -= valueBomb;
                }

                if (isValidIndex(currentRow + 1, currentCol - 1, jagged.Length) && jagged[currentRow + 1][currentCol - 1] > 0)
                {
                    jagged[currentRow + 1][currentCol - 1] -= valueBomb;
                }

                if (isValidIndex(currentRow + 1, currentCol, jagged.Length) && jagged[currentRow + 1][currentCol] > 0)
                {
                    jagged[currentRow + 1][currentCol] -= valueBomb;
                }

                if (isValidIndex(currentRow + 1, currentCol + 1, jagged.Length) && jagged[currentRow + 1][currentCol + 1] > 0)
                {
                    jagged[currentRow + 1][currentCol + 1] -= valueBomb;
                }

                if (isValidIndex(currentRow, currentCol - 1, jagged.Length) && jagged[currentRow][currentCol - 1] > 0)
                {
                    jagged[currentRow][currentCol - 1] -= valueBomb;
                }

                if (isValidIndex(currentRow, currentCol + 1, jagged.Length) && jagged[currentRow][currentCol + 1] > 0)
                {
                    jagged[currentRow][currentCol + 1] -= valueBomb;
                }
            }

            int countAlive = 0;
            int sumAlive = 0;
            for (int row = 0; row < n; row++)
            {
                countAlive += jagged[row].Where(x => x > 0).Count();
                sumAlive += jagged[row].Where(x => x > 0).Sum();
            }
            Console.WriteLine($"Alive cells: {countAlive}");
            Console.WriteLine($"Sum: {sumAlive}");

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        private static bool isValidIndex(int row, int col, int lenght)
        {
            return row >= 0 && row < lenght && col >= 0 && col < lenght;
        }
        private static int[] ReadArray()
        {
            return Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
        }
    }
}
