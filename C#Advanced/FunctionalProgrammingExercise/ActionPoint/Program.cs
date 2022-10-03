using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = (name) => Console.WriteLine(name);
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(names);
        }
    }
}
