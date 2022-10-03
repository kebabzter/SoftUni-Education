using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size,size];
            int row = -1;
            int col = -1;
            int countCoal = 0;
            int rowC = -1;
            int colC = -1;
            for (int r = 0; r < size; r++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = currentRow[c];
                    if (matrix[r, c]=='s')
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case "left":
                        if (isValidIndex(row, col - 1, size))
                        {
                            col -= 1;
                        }
                        break;
                    case "right":
                        if (isValidIndex(row, col + 1, size))
                        {
                            col += 1;
                        }
                        break;
                    case "up":
                        if (isValidIndex(row-1, col, size))
                        {
                            row -= 1;
                        }
                        break;
                    case "down":
                        if (isValidIndex(row + 1, col, size))
                        {
                            row += 1;
                        }
                        break;
                }

                if (matrix[row, col] == 'c')
                {
                    countCoal++;
                    matrix[row, col] = '*';
                    rowC = row;
                    colC = col;
                }
                else if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }
            int countC = 0;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (matrix[r, c] == 'c')
                    {
                        countC++;
                    }
                }
            }
            if (countC == 0)
            {
                Console.WriteLine($"You collected all coals! ({rowC}, {colC})");
            }
            else
            {
                Console.WriteLine($"{countC} coals left. ({row}, {col})");
            }
        }

        private static bool isValidIndex(int row, int col, int lenght)
        {
            return row >= 0 && row < lenght && col >= 0 && col < lenght;
        }
    }
}


