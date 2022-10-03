using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = SumDigits(numbers[i]);
                while (sum>str.Length)
                {
                    sum -= str.Length;
                }
                sb.Append(str[sum]);
                str=str.Remove(str.IndexOf(str[sum]),1);
            }
            Console.WriteLine(sb);
        }

        private static int SumDigits(int num)
        {
            int sum = 0;
            while (num>0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
