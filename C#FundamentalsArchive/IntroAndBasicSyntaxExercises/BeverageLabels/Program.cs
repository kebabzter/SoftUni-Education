using System;

namespace BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());
            Console.WriteLine($"{volume}ml {name}:");
            double energy = energyContent * volume / 100.0;
            double sugar = sugarContent * volume / 100.0;
            Console.WriteLine($"{energy}kcal, {sugar}g sugars");
        }
    }
}
