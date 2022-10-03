using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            double left = Race(numbers, numbers.Count / 2);
            numbers.Reverse();
            double right = Race(numbers, numbers.Count / 2 );
            if (left < right)
            {
                Console.WriteLine($"The winner is left with total time: {left}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {right}");
            }
        }

        private static double Race(List<int> numbers, int end)
        {
            double result = 0;
            for (int i = 0; i < end; i++)
            {
                if (numbers[i] == 0)
                {
                    result *= 0.8;
                }
                else
                {
                    result += numbers[i];
                }
            }
            return result;
        }
    }
}
