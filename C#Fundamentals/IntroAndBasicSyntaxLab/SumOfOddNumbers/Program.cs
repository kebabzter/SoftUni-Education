using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= 2*n; i+=2)
            {
                Console.WriteLine($"{i}");
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
