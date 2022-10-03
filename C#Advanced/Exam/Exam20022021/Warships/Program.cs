using System;
using System.Linq;
using System.Numerics;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            string[] attacks = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int totalCountShipsDestroyed = 0;
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                    else if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                }
            }

            bool flag = false;

            for (int i = 0; i < attacks.Length; i++)
            {
                int[] coordinates = attacks[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int rowAttack = coordinates[0];
                int colAttack = coordinates[1];

                if (rowAttack < 0 || rowAttack >= size || colAttack < 0 || colAttack >= size)
                {
                    continue;
                }

                int firstShips = 0;
                int secondShips = 0;
                if (matrix[rowAttack, colAttack] == '#')
                {
                    firstShips = CountShips(matrix, rowAttack, colAttack, '<');
                    secondShips = CountShips(matrix, rowAttack, colAttack, '>');
                    totalCountShipsDestroyed += firstShips + secondShips;
                    matrix[rowAttack, colAttack] = 'X';
                }
                else if (matrix[rowAttack, colAttack] == '>')
                {
                    secondShips++;
                    totalCountShipsDestroyed++;
                    matrix[rowAttack, colAttack] = 'X';
                }
                else if (matrix[rowAttack, colAttack] == '<')
                {
                    firstShips++;
                    totalCountShipsDestroyed++;
                    matrix[rowAttack, colAttack] = 'X';
                }

                firstPlayerShips -= firstShips;
                secondPlayerShips -= secondShips;

                if (secondPlayerShips == 0)
                {
                    flag = true;
                    Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    break;
                }
                if (firstPlayerShips == 0)
                {
                    flag = true;
                    Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }
        }

        private static int CountShips(char[,] matrix, int row, int col, char symbol)
        {
            int attack = 0;
            if (isValidIndex(matrix, row + 1, col + 1) && (matrix[row + 1, col + 1] == symbol))
            {
                attack++;
                matrix[row + 1, col + 1] = 'X';
            }

            if (isValidIndex(matrix, row + 1, col) && (matrix[row + 1, col] == symbol))
            {
                attack++;
                matrix[row + 1, col] = 'X';
            }

            if (isValidIndex(matrix, row + 1, col - 1) && (matrix[row + 1, col - 1] == symbol))
            {
                attack++;
                matrix[row + 1, col - 1] = 'X';
            }

            if (isValidIndex(matrix, row - 1, col + 1) && (matrix[row - 1, col + 1] == symbol))
            {
                attack++;
                matrix[row - 1, col + 1] = 'X';
            }

            if (isValidIndex(matrix, row - 1, col) && (matrix[row - 1, col] == symbol))
            {
                attack++;
                matrix[row - 1, col] = 'X';
            }

            if (isValidIndex(matrix, row - 1, col - 1) && (matrix[row - 1, col - 1] == symbol))
            {
                attack++;
                matrix[row - 1, col - 1] = 'X';
            }

            if (isValidIndex(matrix, row, col + 1) && (matrix[row, col + 1] == symbol))
            {
                attack++;
                matrix[row, col + 1] = 'X';
            }

            if (isValidIndex(matrix, row , col - 1) && (matrix[row, col - 1] == symbol))
            {
                attack++;
                matrix[row, col - 1] = 'X';
            }
            return attack;
        }

        private static bool isValidIndex(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

    }
}