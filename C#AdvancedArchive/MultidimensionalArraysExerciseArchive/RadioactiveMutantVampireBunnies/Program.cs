using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
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
            char[,] matrix = new char[rows, columns];
            int pRow = -1;
            int pCol = -1;
            for (int i = 0; i < rows; i++)
            {
                char[] current = Console.ReadLine().ToCharArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = current[j];
                    if (matrix[i, j] == 'P')
                    {
                        pRow = i;
                        pCol = j;
                    }
                }
            }
            char[] commands = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;
            foreach (char command in commands)
            {
                int currentRow = pRow;
                int currentCol = pCol;
                if (command == 'U')
                {
                    currentRow -= 1;
                }
                else if (command == 'D')
                {
                    currentRow += 1;
                }
                else if (command == 'L')
                {
                    currentCol -= 1;
                }
                else if (command == 'R')
                {
                    currentCol += 1;
                }

                if (!isValidCell(currentRow, currentCol, rows, columns))
                {
                    isWon = true;
                    matrix[pRow, pCol] = '.';
                    List<int[]> coordinatesB = GetCoordinates(matrix);
                    SpreadBunnies(coordinatesB, matrix);
                }
                else if (matrix[currentRow, currentCol] == '.')
                {
                    matrix[pRow, pCol] = '.';
                    matrix[currentRow, currentCol] = 'P';
                    pRow = currentRow;
                    pCol = currentCol;
                    List<int[]> coordinatesB = GetCoordinates(matrix);
                    SpreadBunnies(coordinatesB, matrix);
                    if (matrix[pRow, pCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (matrix[currentRow, currentCol] == 'B')
                {
                    isDead = true;
                    matrix[pRow, pCol] = '.';
                    pRow = currentRow;
                    pCol = currentCol;
                    List<int[]> coordinatesB = GetCoordinates(matrix);
                    SpreadBunnies(coordinatesB, matrix);
                }


                if (isDead || isWon)
                {
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

            string result = string.Empty;
            if (isWon)
            {
                result = "won";
            }
            else
            {
                result = "dead";
            }
            Console.WriteLine($"{result}: {pRow} {pCol}");
        }

        private static void SpreadBunnies(List<int[]> coordinatesB, char[,] matrix)
        {
            int rowLenght = matrix.GetLength(0);
            int colLenght = matrix.GetLength(1);
            foreach (int[] bCoordinates in coordinatesB)
            {
                int row = bCoordinates[0];
                int col = bCoordinates[1];

                if (isValidCell(row - 1, col, rowLenght, colLenght))
                {
                    matrix[row - 1, col] = 'B';
                }
                if (isValidCell(row + 1, col, rowLenght, colLenght))
                {
                    matrix[row + 1, col] = 'B';
                }
                if (isValidCell(row, col - 1, rowLenght, colLenght))
                {
                    matrix[row, col - 1] = 'B';
                }
                if (isValidCell(row, col + 1, rowLenght, colLenght))
                {
                    matrix[row, col + 1] = 'B';
                }
            }
        }

        private static List<int[]> GetCoordinates(char[,] matrix)
        {
            List<int[]> coordinatesB = new List<int[]>();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'B')
                    {
                        coordinatesB.Add(new int[] { r, c });
                    }
                }
            }
            return coordinatesB;
        }

        private static bool isValidCell(int r, int c, int row, int column)
        {
            return r >= 0 && r < row && c >= 0 && c < column;
        }
    }
}

