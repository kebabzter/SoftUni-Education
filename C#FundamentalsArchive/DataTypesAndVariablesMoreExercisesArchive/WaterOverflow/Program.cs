using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumLiters = 0;
            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                sumLiters += liters;
                if (sumLiters > 255)
                {
                    sumLiters -= liters;
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(sumLiters);
        }
    }
}
