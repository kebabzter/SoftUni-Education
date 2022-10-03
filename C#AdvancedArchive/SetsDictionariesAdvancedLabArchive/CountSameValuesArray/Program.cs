using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(double.Parse)
                  .ToArray();
            Dictionary<double, int> count = new Dictionary<double, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!count.ContainsKey(numbers[i]))
                {
                    count.Add(numbers[i], 0);
                }
                count[numbers[i]]++;
            }
            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}
