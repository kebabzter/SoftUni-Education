using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray().Reverse()));
        }
    }
}
