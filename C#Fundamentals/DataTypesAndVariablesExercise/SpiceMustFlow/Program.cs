using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            if (startingYield<100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);
                return;
            }
            long spice = 0;
            int days = 0;
            while (startingYield>=100)
            {
                days++;
                spice += startingYield - 26;
                startingYield -= 10;
            }
            spice -= 26;
            Console.WriteLine(days);
            Console.WriteLine(spice);
        }
    }
}
