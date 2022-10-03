using System;
using System.Collections.Generic;
using System.Linq;

namespace OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            numbers.RemoveAll(x=>x%2!=0);
            double average = numbers.Average();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= average)
                {
                    numbers[i]--;
                }
                else
                {
                    numbers[i]++;
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
