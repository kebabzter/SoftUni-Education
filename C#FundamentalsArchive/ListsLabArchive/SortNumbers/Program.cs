using System;
using System.Collections.Generic;
using System.Linq;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToList();
            Console.WriteLine(string.Join(" <= ",numbers.OrderBy(x=>x)));
        }
    }
}
