using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                jagged[r] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (input[0]=="END")
                {
                    break;
                }
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);
                if (row>=0&&row<rows&&col>=0&&col<jagged[row].Length)
                {
                    if (input[0]=="Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (input[0]=="Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < jagged[r].Length; c++)
                {
                    Console.Write($"{jagged[r][c]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
