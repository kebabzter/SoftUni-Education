using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int pushElementCount = num[0];
            int popElementCount = num[1];
            int lookElementCount = num[2];
            int[] numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
            Queue<int> numberQueue = new Queue<int>();
            if (pushElementCount <= numbers.Length)
            {
                for (int i = 0; i < pushElementCount; i++)
                {
                    numberQueue.Enqueue(numbers[i]);
                }
            }
            if (popElementCount <= numberQueue.Count)
            {
                for (int i = 0; i < popElementCount; i++)
                {
                    numberQueue.Dequeue();
                }
            }
            if (numberQueue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            if (numberQueue.Contains(lookElementCount))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberQueue.Min());
            }
        }
    }
}
