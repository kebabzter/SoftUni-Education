using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            byte number = byte.Parse(Console.ReadLine());
            long[] arrFibonacci = new long[number];
            arrFibonacci[0] = 1;
            if (number >= 2)
            {
                arrFibonacci[1] = 1;
                for (byte i = 2; i < number; i++)
                {
                    arrFibonacci[i] = arrFibonacci[i - 1] + arrFibonacci[i - 2];
                }
            }
            Console.WriteLine(arrFibonacci[number - 1]);
        }
    }
}
