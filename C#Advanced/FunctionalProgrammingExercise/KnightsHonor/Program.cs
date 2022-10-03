using System;
using System.Linq;

namespace KnightsHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = (name) => Console.WriteLine($"Sir {name}");
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(names);
        }
    }
}
