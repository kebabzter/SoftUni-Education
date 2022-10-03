using System;
using System.Collections.Generic;
using System.Linq;

namespace CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            numbers.Sort();
            int count = 1;
            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i]==numbers[i+1])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} -> {count}");
                    count = 1;
                }
            }
            if (numbers.Count==1)
            {
                Console.WriteLine($"{numbers[0]} -> 1");
            }
            else if (numbers[numbers.Count-1]!=numbers[numbers.Count-2])
            {
                Console.WriteLine($"{numbers[numbers.Count-1]} -> 1");
            }
            else
            {
                Console.WriteLine($"{numbers[numbers.Count - 1]} -> {count}");
            }
        }
    }
}
