using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
           int number = int.Parse(Console.ReadLine());
           Console.WriteLine(Multiply(Math.Abs(number)));
        }
        static int SumOddDigits(int num)
        {
            int sum = 0;
            while (num>0)
            {
                int lastDigits = num % 10;
                if (lastDigits%2!=0)
                {
                    sum += lastDigits;
                }
                num /= 10;
            }
            return sum;
        }
        static int SumEvenDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                int lastDigits = num % 10;
                if (lastDigits % 2 == 0)
                {
                    sum += lastDigits;
                }
                num /= 10;
            }
            return sum;
        }
        static int Multiply(int num)
        {
            return SumOddDigits(num)* SumEvenDigits(num);
        }
    }
}
