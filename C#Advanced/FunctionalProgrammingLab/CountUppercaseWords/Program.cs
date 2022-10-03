using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = str => char.IsUpper(str[0]);
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => predicate(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
