using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();

            int[] numArr = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();
            if (numArr[0]>numbers.Count)
            {
                numArr[0] = numbers.Count;
            }
            if (numArr[1] > numArr[0])
            {
                numArr[1] = numArr[0];
            }
            var newList = numbers.Take(numArr[0]).ToList();
                newList.RemoveRange(0,numArr[1]);
            if (newList.Contains(numArr[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
