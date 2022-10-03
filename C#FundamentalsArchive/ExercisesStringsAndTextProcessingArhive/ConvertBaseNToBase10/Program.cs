using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConvertBaseNToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> nums = new List<BigInteger>();
            nums = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
            int n = (int)nums[0];
            BigInteger number = nums[1];
            BigInteger remainder;
            BigInteger result=0;
            BigInteger currentResult;
            int pow = 0;
            if (n >= 2 && n <= 10)
            {
                while (number > 0)
                {
                    remainder = number % 10;
                    number /= 10;
                    currentResult =remainder*BigInteger.Pow(n, pow);
                    pow++;
                    result+=currentResult;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
