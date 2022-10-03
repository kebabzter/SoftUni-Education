using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour= double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            double totalPriceEgg = priceEgg * 10 * students;
            double apron = priceApron*Math.Ceiling(students+students*0.2);
            int freePackage = students / 5;
            double totalFlour = priceFlour * (students - freePackage);
            double totalPrice = totalPriceEgg + apron + totalFlour;
           
            if (totalPrice<=budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice-budget:f2}$ more needed.");
            }
        }
    }
}
