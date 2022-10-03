using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                 .Split("|", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            List<string> result = new List<string>();
                numbers.Reverse();
            for (int i = 0; i < numbers.Count; i++)
            {
                List<string> current = numbers[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                result.AddRange(current);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
