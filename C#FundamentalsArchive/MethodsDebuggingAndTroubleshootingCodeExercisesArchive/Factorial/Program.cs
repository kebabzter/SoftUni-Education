using System;
using System.Numerics;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fac(number));
        }

        private static BigInteger Fac(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Fac(number - 1);
            }
        }
    }
}
