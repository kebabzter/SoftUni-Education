using System;

namespace RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double discount = 0;
            int price = 0;
            double totalPrice = 0;
            switch (package)
            {
                case "Normal":
                    discount = 0.05;
                    price = 500;
                    break;
                case "Gold":
                    discount = 0.1;
                    price = 750;
                    break;
                case "Platinum":
                    discount = 0.15;
                    price = 1000;
                    break;
            }
            if (groupSize<=50)
            {
                totalPrice = ((2500+price)-(2500 + price)*discount)/groupSize;
                Console.WriteLine("We can offer you the Small Hall");
                Console.WriteLine($"The price per person is {totalPrice:f2}$");
            }
            else if (groupSize<=100)
            {
                totalPrice = ((5000+price)-(5000 + price) * discount) / groupSize;
                Console.WriteLine("We can offer you the Terrace");
                Console.WriteLine($"The price per person is {totalPrice:f2}$");
            }
            else if (groupSize<=120)
            {
                totalPrice = ((7500+price)-(7500 + price) * discount) / groupSize;
                Console.WriteLine("We can offer you the Great Hall");
                Console.WriteLine($"The price per person is {totalPrice:f2}$");
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
