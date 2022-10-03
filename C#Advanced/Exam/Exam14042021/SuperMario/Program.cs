using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];

            int rowM = 0;
            int colM = 0;
            for (int row = 0; row < n; row++)
            {
                jagged[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'M')
                    {
                        rowM = row;
                        colM = col;
                        break;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                lives--;
                string direction = input[0];
                int indexRow = int.Parse(input[1]);
                int indexCol = int.Parse(input[2]);
                jagged[indexRow][indexCol] = 'B';
                switch (direction)
                {
                    case "W":
                        if (rowM - 1 >= 0)
                        {
                            jagged[rowM][colM] = '-';
                            rowM--;
                        }
                        break;
                    case "S":
                        if (rowM + 1 <n)
                        {
                            jagged[rowM][colM] = '-';
                            rowM++;
                        }
                        break;
                    case "A":
                        if (colM - 1 >= 0)
                        {
                            jagged[rowM][colM] = '-';
                            colM--;
                        }
                        break;
                    case "D":
                        if (colM + 1 < n)
                        {
                            jagged[rowM][colM] = '-';
                            colM++;
                        }
                        break;
                }

                if (jagged[rowM][colM] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        jagged[rowM][colM] = 'X';
                        Console.WriteLine($"Mario died at {rowM};{colM}.");
                        break;
                    }
                }

                if (jagged[rowM][colM] == 'P')
                {
                    jagged[rowM][colM] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (lives <= 0)
                {
                    jagged[rowM][colM] = 'X';
                    Console.WriteLine($"Mario died at {rowM};{colM}.");
                    break;
                }
                jagged[rowM][colM] = 'M';
            }
           

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
