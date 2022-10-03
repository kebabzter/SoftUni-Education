using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(x => x * 1.2M)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
