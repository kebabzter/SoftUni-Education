using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
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
            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> queue = new Queue<char>(snake);
            char[,] matrix = new char[rows, columns];
            int count = 1;
            for (int r = rows - 1; r >= 0; r--)
            {
                if (count%2==1)
                {
                    for (int c = columns - 1; c >= 0; c--)
                    {
                        char symbol = queue.Dequeue();
                        matrix[r, c] = symbol;
                        queue.Enqueue(symbol);
                    }
                }
                else
                {
                    for (int c = 0; c < columns; c++)
                    {
                        char symbol = queue.Dequeue();
                        matrix[r, c] = symbol;
                        queue.Enqueue(symbol);
                    }
                }
                count++;
            }

            int[] parameters = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int iRow = parameters[0];
            int iCol = parameters[1];
            int radius = parameters[2];

            matrix[iRow, iCol] = ' ';
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if ((r - iRow) *
                        (r - iRow) +
                        (c - iCol) *
                        (c - iCol)
                        <= radius * radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }

            for (int c = 0; c < columns; c++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int r = rows - 1; r > 0; r--)
                    {
                        if (matrix[r, c] == ' ')
                        {
                            matrix[r, c] = matrix[r - 1, c];
                            matrix[r - 1, c] = ' ';
                        }
                    }
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    Console.Write($"{matrix[r,c]}");
                }
                Console.WriteLine();
            }
        }
    }
}
