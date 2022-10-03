using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = number;
            int sum = 0;
            while (num != 0)
            {
                int currentNumber = num % 10;
                num /= 10;
                int factorial = 1;
                for (int i = 1; i <= currentNumber; i++)
                {
                    factorial *= i;
                }
                sum += factorial;
            }
            if (sum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
