using System;
using System.Linq;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sumOfDigits = 0;
            for (int i = 0; i < n; i++)
            {
                long[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                long firstNumber = numbers[0];
                long secondNumber = numbers[1];
                if (firstNumber >= secondNumber)
                {
                    sumOfDigits = GetSumOfNum(Math.Abs(firstNumber));
                }
                else
                {
                    sumOfDigits = GetSumOfNum(Math.Abs(secondNumber));
                }
                Console.WriteLine(sumOfDigits);
            }
            long GetSumOfNum(long num)
            {
                long sum = 0;
                while (num > 0)
                {
                    sum = sum + num % 10;
                    num = num / 10;
                }
                return sum;
            }

        }
    }
}
