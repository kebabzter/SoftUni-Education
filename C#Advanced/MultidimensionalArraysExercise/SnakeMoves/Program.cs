using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake);

            for (int row = 0; row < rows; row++)
            {
                char[] current = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    char temp = queue.Dequeue();
                    queue.Enqueue(temp);
                    current[col] = temp;
                }
                if (row % 2 == 0)
                {
                    matrix[row] = current;
                }
                else
                {
                    matrix[row] = current.Reverse().ToArray();
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
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
