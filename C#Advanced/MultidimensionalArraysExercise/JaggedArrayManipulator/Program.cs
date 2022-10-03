using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = ReadArray();
            }

            for (int row = 0; row < rows-1; row++)
            {
                if (jagged[row].Length==jagged[row+1].Length)
                {
                    jagged[row]=jagged[row].Select(x => x = x * 2).ToArray();
                    jagged[row+1]=jagged[row+1].Select(x => x = x * 2).ToArray();
                }
                else
                {
                    jagged[row] = jagged[row].Select(x => x = x / 2).ToArray();
                    jagged[row + 1] = jagged[row + 1].Select(x => x = x / 2).ToArray();
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currentRow = int.Parse(command[1]);
                int currentCol = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (currentRow >= 0 && currentCol >= 0 && currentRow < rows && currentCol < jagged[currentRow].Length)
                {
                    if (command[0] == "Add")
                    {
                        jagged[currentRow][currentCol] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jagged[currentRow][currentCol] -= value;
                    }
                }
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }

        private static double[] ReadArray()
        {
            return Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(double.Parse)
                   .ToArray();
        }
    }
}
