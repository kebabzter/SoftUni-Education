using System;

namespace X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int topBottom = n / 2;
            int addSpace = 0;
            for (int i = 0; i < topBottom; i++)
            {
                Console.WriteLine($"{ new string(' ', i)}x{new string(' ', n-2-addSpace)}x");
                addSpace += 2;
            }
            Console.WriteLine($"{new string(' ',(n-1)/2)}x");
            addSpace = 0;
            for (int j = topBottom; j > 0; j--)
            {
                Console.WriteLine($"{ new string(' ', j-1)}x{new string(' ', 1 + addSpace)}x");
                addSpace += 2;
            }
        }
    }
}
