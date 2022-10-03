using System;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(number));
        }

        private static long Fib(int number)
        {
            if (number==0)
            {
                return 1;
            }
            else if (number==1 || number==2)
            {
                return number;
            }
            else
            {
                return Fib(number - 1) + Fib(number-2);
            }
        }
    }
}
