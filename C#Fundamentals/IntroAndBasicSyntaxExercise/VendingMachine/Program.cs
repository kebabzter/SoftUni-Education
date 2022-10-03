using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            double sumMoney = 0;
            double price = 0;
            while (input != "start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    sumMoney += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine().ToLower();
            }
            string command = Console.ReadLine().ToLower();
            bool flag = true;
            while (command != "end")
            {
                switch (command)
                {
                    case "nuts":
                        price = 2.0;
                        break;
                    case "water":
                        price = 0.7;
                        break;
                    case "crisps":
                        price = 1.5;
                        break;
                    case "soda":
                        price = 0.8;
                        break;
                    case "coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        flag = false;
                        break;
                }
                if (sumMoney - price >= 0 && flag)
                {
                    Console.WriteLine($"Purchased {command}");
                    sumMoney -= price;
                }
                else if (sumMoney - price < 0 && flag)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                command = Console.ReadLine().ToLower();
                flag = true;
            }
            Console.WriteLine($"Change: {sumMoney:f2}");

        }
    }
}
