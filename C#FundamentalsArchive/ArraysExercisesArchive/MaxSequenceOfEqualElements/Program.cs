using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxCount = 0;
            int maxNum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentCount = 1;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i]==arr[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentCount>maxCount)
                {
                    maxCount = currentCount;
                    maxNum = arr[i];
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write($"{maxNum} ");
            }
        }
    }
}
