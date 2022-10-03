using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row]= Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                string[] command = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                if (row<0||row>=n||col<0||col>=jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command[0]=="Add")
                {
                    jagged[row][col] += int.Parse(command[3]);
                }
                else if (command[0]== "Subtract")
                {
                    jagged[row][col] -= int.Parse(command[3]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ",jagged[i]));
            }
        }
    }
}
