using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = Console.ReadLine().ToCharArray();
            }
            int removedKnight = 0;
            while (true)
            {
                int kRow = -1;
                int kCol = -1;
                int maxAttacked = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (jagged[row][col]=='K')
                        {
                            int tempAttacked = CountAttacked(jagged,row,col);
                            if (tempAttacked>maxAttacked)
                            {
                                maxAttacked = tempAttacked;
                                kRow = row;
                                kCol = col;
                            }
                        }
                    }
                }

                if (maxAttacked>0)
                {
                    jagged[kRow][kCol] = '0';
                    removedKnight++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(removedKnight);
        }

        private static int CountAttacked(char[][] jagged, int row, int col)
        {
            int attack = 0;
            if (isValidIndex(row+1,col-2,jagged.Length)&&jagged[row+1][col-2]=='K')
            {
                attack++;
            }

            if (isValidIndex(row + 1, col + 2, jagged.Length) && jagged[row + 1][col + 2] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row - 1, col - 2, jagged.Length) && jagged[row - 1][col - 2] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row - 1, col + 2, jagged.Length) && jagged[row - 1][col + 2] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row + 2, col - 1, jagged.Length) && jagged[row + 2][col - 1] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row + 2, col + 1, jagged.Length) && jagged[row + 2][col + 1] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row - 2, col - 1, jagged.Length) && jagged[row - 2][col - 1] == 'K')
            {
                attack++;
            }

            if (isValidIndex(row - 2, col + 1, jagged.Length) && jagged[row - 2][col + 1] == 'K')
            {
                attack++;
            }
            return attack;
        }

        private static bool isValidIndex(int row, int col, int lenght)
        {
            return row >= 0&& row<lenght&&col>=0&&col<lenght;
        }
    }
}
