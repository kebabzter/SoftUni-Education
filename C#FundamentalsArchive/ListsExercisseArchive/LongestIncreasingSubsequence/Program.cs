using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            int[] length = new int[numbers.Count];
            int[] prev = new int[numbers.Count];
            int maxLength = 0;
            int lastIndex = -1;
            for (int i = 0; i < numbers.Count; i++)
            {
                length[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i] && length[j] >= length[i])
                    {
                        length[i] = 1 + length[j];
                        prev[i] = j;
                    }
                }
                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }
            List<int> longestSeq = new List<int>();
            for (int i = 0; i < maxLength; i++)
            {
                longestSeq.Add(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            longestSeq.Reverse();
            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}
