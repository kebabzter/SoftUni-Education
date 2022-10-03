using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
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
            Stack<int> numberStack = new Stack<int>();
            if (pushElementCount <= numbers.Length)
            {
                for (int i = 0; i < pushElementCount; i++)
                {
                    numberStack.Push(numbers[i]);
                }
            }
            if (popElementCount <= numberStack.Count)
            {
                for (int i = 0; i < popElementCount; i++)
                {
                    numberStack.Pop();
                }
            }
            if (numberStack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            if (numberStack.Contains(lookElementCount))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberStack.Min());
            }
        }
    }
}
