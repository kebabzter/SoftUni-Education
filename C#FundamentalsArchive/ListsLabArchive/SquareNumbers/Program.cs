using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var result = numbers.Where(x => Math.Sqrt(x) == (int)Math.Sqrt(x))
                .OrderByDescending(x => x)
                .ToList();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
