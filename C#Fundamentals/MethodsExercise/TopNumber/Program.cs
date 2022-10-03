using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 17; i <=number; i++)
            {
                TopNum(i);
            } 
        }

        static int SumDigits(int number)
        {
            int sum = 0;
            while (number>0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static bool OddDigits(int number)
        {
            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum%2!=0)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }
        static void TopNum(int number)
        {
            if (SumDigits(number)%8==0&&OddDigits(number))
            {
                Console.WriteLine(number);
            }
        }
    }
}
