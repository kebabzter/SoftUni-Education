using System;
using System.Linq;

namespace ReverseAnArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            array=array.Reverse().ToArray();
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
