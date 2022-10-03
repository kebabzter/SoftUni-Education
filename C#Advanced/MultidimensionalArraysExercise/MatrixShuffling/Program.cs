using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = ReadMatrix(rows, cols);

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.Length==5&&command[0]=="swap"&&int.Parse(command[1])<rows&&int.Parse(command[2])<cols)
                {
                    int firstRow = int.Parse(command[1]);
                    int firstCol = int.Parse(command[2]);
                    int secondRow = int.Parse(command[3]);
                    int secondCol = int.Parse(command[4]);

                    string temp = matrix[firstRow,firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow,secondCol];
                    matrix[secondRow, secondCol] = temp;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
        }

        static void PrintMatrix(string[,]matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
