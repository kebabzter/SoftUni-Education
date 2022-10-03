using System;
using System.Collections.Generic;

namespace PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(", ",ListPrime(startNum,endNum)));
        }

        private static List<int> ListPrime(int numStart, int numEnd)
        {
            List<int> listNumberPrime = new List<int>();
            for (int i = numStart; i <=numEnd; i++)
            {
                if (IsPrime(i))
                {
                    listNumberPrime.Add(i);
                }
            }
            return listNumberPrime;
        }
        private static bool IsPrime(long number)
        {
            if (number <= 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
