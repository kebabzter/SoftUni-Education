using System;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            bool flag = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "special" || input == "regular")
                {
                    if (input == "special")
                    {
                        flag = true;
                    }
                    break;
                }
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                totalPrice += price;

            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {totalPrice * 0.2:f2}$");
                totalPrice += totalPrice * 0.2;
                if (flag)
                {
                    totalPrice -= totalPrice * 0.1;
                }
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
