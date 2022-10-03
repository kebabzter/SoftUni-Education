using System;
using System.Numerics;

namespace FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(CountZero(Fac(number)));
        }

        private static int CountZero(BigInteger number)
        {
            int count=0;
            while (number>0)
            {
                if (number%10==0)
                {
                    count++;
                    number /= 10;
                }
                else
                {
                    break;
                }
            }
            return count;
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
