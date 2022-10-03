using System;
using System.Collections.Generic;
using System.Globalization;

namespace SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            List<DateTime> info = new List<DateTime>();
            for (int i = 0; i < input.Length; i++)
            {
                info.Add(DateTime.ParseExact(input[i],"HH:mm", CultureInfo.InvariantCulture));
            }
            info.Sort();
            List<string> result = new List<string>();
            foreach (var item in info)
            {
                result.Add(item.ToString("HH:mm",CultureInfo.InvariantCulture));
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
