using System;

namespace NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            if (long.TryParse(num,out long integer))
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
