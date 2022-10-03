using System;
using System.Linq;

namespace Rubik_sMatrix
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
            int[,] matrix = new int[rows, columns];
            int count = 1;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    matrix[r, c] = count;
                    count++;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int rC = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);
                switch (direction)
                {
                    case "up":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            int temp = matrix[0,rC];
                            for (int r = 0; r < rows-1; r++)
                            {
                                matrix[r, rC] = matrix[r+1,rC];
                            }
                            matrix[rows - 1, rC] = temp;
                        }
                        break;
                    case "down":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            int temp = matrix[rows-1,rC];
                            for (int r = rows-1; r > 0; r--)
                            {
                                matrix[r, rC] = matrix[r - 1, rC];
                            }
                            matrix[0, rC] = temp;
                        }
                        break;
                    case "left":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            int temp = matrix[rC, 0];
                            for (int c = 0; c < columns - 1; c++)
                            {
                                matrix[rC, c] = matrix[rC, c+1];
                            }
                            matrix[rC,columns - 1] = temp;
                        }
                        break;
                    case "right":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            int temp = matrix[rC,columns - 1];
                            for (int c =columns - 1; c > 0; c--)
                            {
                                matrix[rC, c] = matrix[rC,c - 1];
                            }
                            matrix[rC,0] = temp;
                        }
                        break;
                }
            }
            count = 1;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (matrix[r,c]==count)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        bool flag = false;
                        for (int newR = r; newR < rows; newR++)
                        {
                            for (int newC = 0; newC < columns; newC++)
                            {
                                if (matrix[newR,newC]==count)
                                {
                                    flag = true;
                                    Console.WriteLine($"Swap ({r}, {c}) with ({newR}, {newC})");
                                    matrix[newR, newC] = matrix[r, c];
                                    matrix[r, c] = count;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                    }
                    count++;
                }
            }
        }
    }
}
