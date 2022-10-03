using System;
using System.Linq;

namespace PredicateNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Predicate<string> filter = name => name.Length <= n;
            string[] names = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in names.Where(name => filter(name)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
