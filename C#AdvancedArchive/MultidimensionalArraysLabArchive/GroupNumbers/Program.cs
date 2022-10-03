using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[][] jagged = new int[3][];
            List<int> zero = new List<int>();
            List<int> one = new List<int>();
            List<int> two = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int remainder = Math.Abs(numbers[i] % 3);
                if (remainder==0)
                {
                    zero.Add(numbers[i]);
                }
                else if (remainder==1)
                {
                    one.Add(numbers[i]);
                }
                else if (remainder==2)
                {
                    two.Add(numbers[i]);
                }
            }
            jagged[0] = zero.ToArray();
            jagged[1] = one.ToArray();
            jagged[2] = two.ToArray();

            for (int r = 0; r < 3; r++)
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
