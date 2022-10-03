using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            bool isSpecialNum = false;
            for (int i = 1; i <= numbers; i++)
            {
                int sum = 0;
                int current = i;
                while (current > 0)
                {
                    sum += current % 10;
                    current = current / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecialNum);
            }
        }
    }
}