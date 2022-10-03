using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
            int rows = rowCol[0];
            int columns = rowCol[1];
            int[][] jagged = new int[rows][];
            int count = 1;
            for (int r = 0; r < rows; r++)
            {
                jagged[r] = new int[columns];
                for (int c = 0; c < columns; c++)
                {
                    jagged[r][c] = count;
                    count++;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Nuke it from orbit")
                {
                    break;
                }
                int[] parameters = input
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToArray();
                int row = parameters[0];
                int col = parameters[1];
                int radius = parameters[2];

                for (int r = row - radius; r <= row + radius; r++)
                {
                    if (IsValid(r, col, jagged))
                    {
                        jagged[r][col] = -1;
                    }
                }

                for (int c = col - radius; c <= col + radius; c++)
                {
                    if (IsValid(row, c,jagged))
                    {
                        jagged[row][c] = -1;
                    }
                }

                for (int r = 0; r < jagged.Length; r++)
                {
                    
                    if (jagged[r].Any(c => c == -1))
                    {
                        jagged[r] = jagged[r].Where(n => n > 0).ToArray();
                    }

                    if (jagged[r].Length < 1)
                    {
                        jagged = jagged.Take(r).Concat(jagged.Skip(r + 1)).ToArray();
                        r--;
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row.Where(n => n > 0)));
            }
        }
        private static bool IsValid(int row, int col, int[][] j)
        {
            return row >= 0 && row < j.Length && col >= 0 && col < j[row].Length;
        }
    }
}
