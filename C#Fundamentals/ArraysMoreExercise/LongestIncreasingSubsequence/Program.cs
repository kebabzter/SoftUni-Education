using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] length = new int[arrNumbers.Length];
            int[] prev = new int[arrNumbers.Length];
            int maxLength = 0;
            int lastIndex = -1;
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                length[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (arrNumbers[j] < arrNumbers[i] && length[j] >= length[i])
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
                longestSeq.Add(arrNumbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            longestSeq.Reverse();
            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}
