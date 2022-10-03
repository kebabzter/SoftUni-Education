using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            int rows = size[0];
            int cols = size[1];
            int pRow = -1;
            int pCol = -1;
            bool isDead = false;
            bool isWon = false;
            char[,] matrix = new char[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'P')
                    {
                        pRow = row;
                        pCol = col;
                    }
                }
            }
            char[] directions = Console.ReadLine().ToCharArray();

            foreach (char direction in directions)
            {
                int newPRow = pRow;
                int newPCol = pCol;
                switch (direction)
                {
                    case 'U':
                        newPRow--;
                        break;
                    case 'D':
                        newPRow++;
                        break;
                    case 'L':
                        newPCol--;
                        break;
                    case 'R':
                        newPCol++;
                        break;
                }
                matrix[pRow, pCol] = '.';
                isWon= !isValidCell(newPRow, newPCol, rows, cols);
                if (isValidCell(newPRow, newPCol, rows, cols))
                {
                    if (matrix[newPRow,newPCol]=='.')
                    {
                        matrix[newPRow, newPCol] = 'P';
                    }
                    else if (matrix[newPRow, newPCol] == 'B')
                    {
                        isDead = true;
                    }
                    pRow = newPRow;
                    pCol = newPCol;
                }

                List<int[]> bIndex = GetBIndex(matrix);
                SpredBunnies(bIndex, matrix);
                if (matrix[pRow,pCol]=='B')
                {
                    isDead = true;
                }

                if (isWon||isDead)
                {
                    break;
                } 
            }
            PrintMatrix(matrix);

            string result = string.Empty;
            if (isWon)
            {
                result += "won: ";
            }
            else
            {
                result += "dead: ";
            }
            result += $"{pRow} {pCol}";
            Console.WriteLine(result);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static void SpredBunnies(List<int[]> bIndex, char[,] matrix)
        {
            foreach (var item in bIndex)
            {
                int bRow = item[0];
                int bCol = item[1];
                if (isValidCell(bRow-1,bCol,matrix.GetLength(0),matrix.GetLength(1)))
                {
                    matrix[bRow - 1, bCol] = 'B';
                }

                if (isValidCell(bRow + 1, bCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bRow + 1, bCol] = 'B';
                }

                if (isValidCell(bRow, bCol-1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bRow, bCol-1] = 'B';
                }

                if (isValidCell(bRow, bCol+1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bRow, bCol+1] = 'B';
                }
            }
        }

        private static List<int[]> GetBIndex(char[,] matrix)
        {
            List<int[]> bIndex = new List<int[]>();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c]=='B')
                    {
                        bIndex.Add(new[] {r,c});
                    }
                }
            }
            return bIndex;
        }

        private static bool isValidCell(int newPRow, int newPCol, int rows, int cols)
        {
            return newPRow >= 0 && newPRow < rows && newPCol >= 0 && newPCol < cols;
        }
    }
}
