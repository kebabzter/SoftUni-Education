using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Where(x => x.Length%2==0)
               .ToList()
               .ForEach(word => Console.WriteLine(word));
        }
    }
}
