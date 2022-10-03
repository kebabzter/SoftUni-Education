using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num]++;
            }
            var result = numbers.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, v => v.Value);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
