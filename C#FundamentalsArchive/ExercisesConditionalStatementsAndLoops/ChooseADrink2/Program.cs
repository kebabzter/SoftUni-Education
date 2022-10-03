using System;

namespace ChooseADrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;
            switch (profession)
            {
                case "Athlete":
                    price = 0.70;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = 1;
                    break;
                case "SoftUni Student":
                    price = 1.70;
                    break;
                default:
                   price = 1.20;
                    break;
            }
            double totalPrice = price * quantity;
            Console.WriteLine($"The {profession} has to pay {totalPrice:f2}.");
        }
    }
}
