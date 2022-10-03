using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int row = -1;
            int col = -1;
            int pollinates = 0;
            for (int r = 0; r < size; r++)
            {
                char[] current = Console.ReadLine().ToCharArray();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = current[c];
                    if (matrix[r, c] == 'B')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
            string command = Console.ReadLine();
            bool flag = true;
            while (true)
            {
                if (command == "End")
                {
                    break;
                }
                switch (command)
                {
                    case "up":
                        if (isValidCell(row - 1, col, size))
                        {
                            matrix[row, col] = '.';
                            row -= 1;
                        }
                        else
                        {
                            flag = false;
                            matrix[row, col] = '.';
                            break;
                        }
                        break;
                    case "down":
                        if (isValidCell(row + 1, col, size))
                        {
                            matrix[row, col] = '.';
                            row += 1;
                        }
                        else
                        {
                            flag = false;
                            matrix[row, col] = '.';
                            break;
                        }
                        break;
                    case "left":
                        if (isValidCell(row, col - 1, size))
                        {
                            matrix[row, col] = '.';
                            col -= 1;
                        }
                        else
                        {
                            flag = false;
                            matrix[row, col] = '.';
                            break;
                        }
                        break;
                    case "right":
                        if (isValidCell(row, col + 1, size))
                        {
                            matrix[row, col] = '.';
                            col += 1;
                        }
                        else
                        {
                            flag = false;
                            matrix[row, col] = '.';
                            break;
                        }
                        break;
                }
                if (!flag)
                {
                    break;
                }

                if (matrix[row, col] == 'f')
                {
                    pollinates++;
                    matrix[row, col] = 'B';
                }
                else if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = 'B';
                    continue;
                }
                else
                {
                    matrix[row, col] = 'B';
                }

                command = Console.ReadLine();
            }

            if (!flag)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinates>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinates} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinates} flowers more");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        private static bool isValidCell(int r, int c, int length)
        {
            return r >= 0 && r < length && c >= 0 && c < length;
        }

    }
}
