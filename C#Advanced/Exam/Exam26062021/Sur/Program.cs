using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            int collected = 0;
            int opponent = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = line;
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                if (command == "Gong")
                {
                    break;
                }

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (command == "Find" && ValidCords(row, col, matrix))
                {
                    if (matrix[row][col] == 'T')
                    {
                        collected++;
                        matrix[row][col] = '-';
                    }
                }
                else if (command == "Opponent" && ValidCords(row, col, matrix))
                {
                    string direction = input[3];
                    opponent += Move(matrix, row, col, direction);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {collected}");
            Console.WriteLine($"Opponent's tokens: {opponent}");
        }

        private static int Move(char[][] matrix, int row, int col, string direction)
        {
            int collected = 0;

            if (matrix[row][col] == 'T')
            {
                collected++;
                matrix[row][col] = '-';
            }

            for (int i = 0; i < 3; i++)
            {
                if (direction == "up" && ValidCords(row - 1, col, matrix))
                {
                    row--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "down" && ValidCords(row + 1, col, matrix))
                {
                    row++;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "left" && ValidCords(row, col - 1, matrix))
                {
                    col--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "right" && ValidCords(row, col + 1, matrix))
                {
                    col++;
                    collected += GetToken(matrix, row, col);
                }
            }

            return collected;
        }

        private static int GetToken(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'T')
            {
                matrix[row][col] = '-';
                return 1;
            }

            return 0;
        }

        private static bool ValidCords(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}