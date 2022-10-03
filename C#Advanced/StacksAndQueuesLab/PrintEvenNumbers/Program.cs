using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            Queue<int> numbers = new Queue<int>(input);

            var result = numbers.Where(x=>x%2==0);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
