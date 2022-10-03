using System;
using System.Collections.Generic;
using System.Linq;

namespace SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => string.Concat(x.Reverse()))
                    .Select(int.Parse)
                    .ToList();
            Console.WriteLine(string.Join(" ",numbers.Sum()));
        }
    }
}
