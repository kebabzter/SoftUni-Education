using System;

namespace ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands= int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int fRow = 0;
            int fCol = 0;
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row,col]=='f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                }
            }

            int oldRow = 0;
            int oldCol = 0;
            bool isWon = false;
            matrix[fRow, fCol] = '-';
            string command = Console.ReadLine();
            for (int i = 0; i <countCommands; i++)
            {
                oldRow = fRow;
                oldCol = fCol;
                switch (command)
                {
                    case "up":
                        oldRow = fRow;
                        if (fRow==0)
                        {
                            fRow = n - 1;
                        }
                        else
                        {
                            fRow--;
                        }
                        break;
                    case "down":
                        oldRow = fRow;
                        if (fRow == n-1)
                        {
                            fRow = 0;
                        }
                        else
                        {
                            fRow++;
                        }
                        break;
                    case "left":
                        oldCol = fCol;
                        if (fCol == 0)
                        {
                            fCol = n - 1;
                        }
                        else
                        {
                            fCol--;
                        }
                        break;
                    case "right":
                        oldCol = fCol;
                        if (fCol == n-1)
                        {
                            fCol = 0;
                        }
                        else
                        {
                            fCol++;
                        }
                        break;
                }
             
                if (matrix[fRow, fCol] =='F')
                {
                    isWon = true;
                    break;
                }
                else if (matrix[fRow, fCol] == 'B')
                {
                    i--;
                    continue;
                }
                else if (matrix[fRow, fCol] == 'T')
                {
                    fRow = oldRow;
                    fCol = oldCol;
                }
                if (i < countCommands - 1)
                {
                    command = Console.ReadLine();
                }
            }

            matrix[fRow, fCol] = 'f';
            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
