using System;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            double avg = numbers.Average();
            int[] result = numbers
                .Where(x => x > avg)
                .OrderByDescending(x => x)
                .Take(5)
                .ToArray();

            if (result.Length==0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ",result));
            }
        }
    }
}
