using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jagged = new char[rows][];
            int collected = 0;
            int opponent = 0;
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Gong")
                {
                    break;
                }

                string[] currentCommand = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = currentCommand[0];
                int row = int.Parse(currentCommand[1]);
                int col = int.Parse(currentCommand[2]);

                if (command == "Find" && ValidIndex(row, col, jagged))
                {
                    if (jagged[row][col] == 'T')
                    {
                        collected++;
                        jagged[row][col] = '-';
                    }
                }
                else if (command == "Opponent" && ValidIndex(row, col, jagged))
                {
                    string direction = currentCommand[3];
                    opponent += Move(jagged, row, col, direction);
                }
            }


            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
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
                if (direction == "up" && ValidIndex(row - 1, col, matrix))
                {
                    row--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "down" && ValidIndex(row + 1, col, matrix))
                {
                    row++;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "left" && ValidIndex(row, col - 1, matrix))
                {
                    col--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "right" && ValidIndex(row, col + 1, matrix))
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

        private static bool ValidIndex(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}
