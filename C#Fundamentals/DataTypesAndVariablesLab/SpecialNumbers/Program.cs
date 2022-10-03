using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <=number; i++)
            {
                int sum = 0;
                int current = i;
                while (current > 0)
                {
                    sum += current % 10;
                    current/=  10;
                }
                Console.WriteLine($"{i} -> {(sum == 5) || (sum == 7) || (sum == 11)}");
            }
        }
    }
}
