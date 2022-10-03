using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SortedDictionary<int, int> countNumbers = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (countNumbers.ContainsKey(numbers[i]))
                {
                    countNumbers[numbers[i]]++;
                }
                else
                {
                    countNumbers.Add(numbers[i], 1);
                }
            }

            foreach (var item in countNumbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
