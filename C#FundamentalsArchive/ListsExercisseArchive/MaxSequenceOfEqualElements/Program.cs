using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            int maxCount = 0;
            int num = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    num = numbers[i];
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{num} ");
            }
        }
    }
}
