using System;
using System.Collections.Generic;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int countK = numbers.Length / 4;
            var leftPart = numbers.Take(countK).Reverse().ToArray();
            var rightPart = numbers.Reverse().Take(countK).ToArray();
            var firstRow = leftPart.Concat(rightPart).ToArray();
            var secondRow = numbers.Skip(countK).Take(2 * countK).ToArray();
            var sum = firstRow.Select((x, index) => x + secondRow[index]).ToArray();
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
