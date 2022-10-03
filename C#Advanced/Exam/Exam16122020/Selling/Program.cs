using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = -1;
            int col = -1;

            for (int r = 0; r < n; r++)
            {
                char[] current = Console.ReadLine().ToCharArray();

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = current[c];
                    if (matrix[r, c] == 'S')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
            bool flag = true;
            int money = 0;
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":

                        if (isValidCell(row - 1, col, n))
                        {
                            matrix[row, col] = '-';
                            row -= 1;
                        }
                        else
                        {
                            matrix[row, col] = '-';
                            flag = false;
                            break;
                        }
                        break;
                    case "down":
                        if (isValidCell(row + 1, col, n))
                        {
                            matrix[row, col] = '-';
                            row += 1;
                        }
                        else
                        {
                            matrix[row, col] = '-';
                            flag = false;
                            break;
                        }
                        break;
                    case "left":
                        if (isValidCell(row, col - 1, n))
                        {
                            matrix[row, col] = '-';
                            col -= 1;
                        }
                        else
                        {
                            matrix[row, col] = '-';
                            flag = false;
                            break;
                        }
                        break;
                    case "right":
                        if (isValidCell(row, col + 1, n))
                        {
                            matrix[row, col] = '-';
                            col += 1;
                        }
                        else
                        {
                            matrix[row, col] = '-';
                            flag = false;
                            break;
                        }
                        break;
                }
               
                if (!flag)
                {
                    break;
                }


                if (matrix[row, col] == 'O')
                {
                    for (int r = 0; r < n; r++)
                    {
                        for (int c = 0; c < n; c++)
                        {
                            if (matrix[r, c] == 'O' && r != row && c != col)
                            {
                                matrix[row, col] = '-';
                                row = r;
                                col = c;
                            }
                        }
                    }
                }
                else if (char.IsDigit(matrix[row,col]))
                {
                    money += int.Parse(matrix[row, col].ToString());
                    matrix[row, col] = '-';
                }

                if (money >= 50)
                {
                    matrix[row, col] = 'S';
                    break;
                }

            }
            if (!flag)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }


        }
        public static bool isValidCell(int r, int c, int length)
        {
            return r >= 0 && r < length && c >= 0 && c < length;
        }

    }
}