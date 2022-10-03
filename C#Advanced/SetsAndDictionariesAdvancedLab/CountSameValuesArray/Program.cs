using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Dictionary<double, int> countNum = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!countNum.ContainsKey(number))
                {
                    countNum.Add(number,0);
                }
                countNum[number]++;
            }

            foreach (var item in countNum)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
