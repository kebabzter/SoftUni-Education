using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            int numberMonth = int.Parse(Console.ReadLine());
            if (numberMonth>=1 && numberMonth<=12)
            {
                Console.WriteLine($"{months[numberMonth-1]}");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
