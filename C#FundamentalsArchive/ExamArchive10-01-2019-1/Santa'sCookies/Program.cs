using System;

namespace Santa_sCookies
{
    class Program
    {
        static void Main(string[] args)
        {
            int batches = int.Parse(Console.ReadLine());
            int allCookies = 0;
            for (int i = 0; i < batches; i++)
            {
                int flour = int.Parse(Console.ReadLine());
                int sugar = int.Parse(Console.ReadLine());
                int cocoa = int.Parse(Console.ReadLine());
                int flourCups =  flour / 140;
                int sugarSpoons = sugar / 20;
                int cocoaSpoons = cocoa / 10;
                if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                }
                else
                {
                    double minInd = Math.Min(flourCups, Math.Min(sugarSpoons, cocoaSpoons));
                    int totalCookies = ((int)Math.Floor(170 * minInd / 25)/5);
                    Console.WriteLine($"Boxes of cookies: {totalCookies}");
                    allCookies += totalCookies;
                }
            }
            Console.WriteLine($"Total boxes: {allCookies}");
            
        }
    }
}
