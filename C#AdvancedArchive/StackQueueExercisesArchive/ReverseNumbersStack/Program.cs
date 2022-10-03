using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numStack = new Stack<int>(numbers);
            Console.WriteLine(string.Join(" ",numStack));
        }
    }
}
