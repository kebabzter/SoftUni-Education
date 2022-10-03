using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double price = 0;
            double totalSpend = 0;
            while (input != "Game Time")
            {
                bool flag = false;
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        flag = true;
                        break;
                }
                if (flag)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (currentBalance == price)
                {
                    Console.WriteLine($"Bought {input}");
                    Console.WriteLine("Out of money!");
                    totalSpend += price;
                    return;
                }
                else if (currentBalance < price)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    Console.WriteLine($"Bought {input}");
                    currentBalance -= price;
                    totalSpend += price;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${currentBalance:f2}");
        }
    }
}
