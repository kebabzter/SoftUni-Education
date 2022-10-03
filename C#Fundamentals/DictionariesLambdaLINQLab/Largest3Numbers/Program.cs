using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x=>x)
                .Take(3)
                .ToList()
                .ForEach(numbers=>Console.Write($"{numbers} "));
        }
    }
}
