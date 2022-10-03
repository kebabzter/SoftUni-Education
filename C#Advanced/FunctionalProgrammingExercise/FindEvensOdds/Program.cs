using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            string evenOdd = Console.ReadLine();
            Predicate<int> predicate = evenOdd == "odd"
                ? new Predicate<int>((number) => number % 2 != 0)
                : new Predicate<int>((number) => number % 2 == 0);
            List<int> result = new List<int>();
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
