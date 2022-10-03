using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                .ToList();
            int minElement = int.MaxValue;
            int maxElement = int.MinValue;
            if (firstNumbers.Count>secondNumbers.Count)
            {
                minElement = Math.Min(firstNumbers[firstNumbers.Count - 1], firstNumbers[firstNumbers.Count - 2]);
                maxElement = Math.Max(firstNumbers[firstNumbers.Count - 1], firstNumbers[firstNumbers.Count - 2]);
                secondNumbers.Reverse();
            }
            else
            {
                secondNumbers.Reverse();
                minElement = Math.Min(secondNumbers[secondNumbers.Count - 1], secondNumbers[secondNumbers.Count - 2]);
                maxElement = Math.Max(secondNumbers[secondNumbers.Count - 1], secondNumbers[secondNumbers.Count - 2]);
                secondNumbers.RemoveAt(secondNumbers.Count - 1);
                secondNumbers.RemoveAt(secondNumbers.Count - 1);
            }
            var filterList = MixedLists(firstNumbers, secondNumbers).Where(x => x > minElement && x < maxElement).ToList();
            filterList.Sort();
            Console.WriteLine(string.Join(" ",filterList));
        }

        private static List<int> MixedLists(List<int> firstNumbers, List<int> secondNumbers)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < secondNumbers.Count; i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }
            return result;
        }
    }
}
