using System;

namespace DrawFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintHeaderFooter(number);
            for (int i = 0; i <number-2; i++)
            {
                PrintMiddle(number);
            }
            PrintHeaderFooter(number);
        }
        static void PrintHeaderFooter(int num)
        {
            Console.WriteLine(new string('-',2*num));
        }
        static void PrintMiddle(int num)
        {
            Console.Write('-');
            for (int i = 1; i < num; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }
    }
}
