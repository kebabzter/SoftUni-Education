using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());
            double price = priceHeadset * (countGames / 2) + priceMouse * (countGames / 3) + priceKeyboard * (countGames / 6) + priceDisplay * (countGames / 12);
            Console.WriteLine($"Rage expenses: {price:f2} lv.");
        }
    }
}
