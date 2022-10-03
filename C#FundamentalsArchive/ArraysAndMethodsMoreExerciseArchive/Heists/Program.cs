using System;
using System.Linq;

namespace Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices= Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int jewelsPrice = prices[0];
            int goldPrice = prices[1];
            long totalPrice = 0;
            long totalExpenses = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Jail Time")
                {
                    break;
                }
                string[] information = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string info = information[0];
                int expenses = int.Parse(information[1]);
                int countJewels = info.Count(x => x.Equals('%'));
                int countGold = info.Count(x => x.Equals('$'));
                totalPrice += countJewels * jewelsPrice + countGold * goldPrice;
                totalExpenses += expenses;
            }
            if (totalPrice >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalPrice-totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalExpenses-totalPrice}.");
            }
        }
    }
}
