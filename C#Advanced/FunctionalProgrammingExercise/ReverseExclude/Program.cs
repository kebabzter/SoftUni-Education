using System;
using System.Linq;

namespace ReverseExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
            int divisible = int.Parse(Console.ReadLine());
            Predicate<int> filter = numbers => numbers % divisible != 0;
            Action<int[]> printer = number => Console.WriteLine(string.Join(" ", number.Reverse().Where(x=>filter(x))));
            printer(numbers);
        }
    }
}
