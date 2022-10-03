using System;
using System.Linq;

namespace UpgradedMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productName = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            long[] quantities = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            decimal[] productPrice = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(decimal.Parse)
                .ToArray();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                string[] info = input
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameProduct = info[0];
                long quantityOrdered = long.Parse(info[1]);
                int index = Array.IndexOf(productName, nameProduct);
                long inventoryQuantity = 0;
                if (index<=quantities.Length-1)
                {
                    inventoryQuantity = quantities[index];
                }
                if (inventoryQuantity>=quantityOrdered)
                {
                    Console.WriteLine($"{nameProduct} x {quantityOrdered} costs {productPrice[index]*quantityOrdered:f2}");
                    quantities[index] -= quantityOrdered;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {nameProduct}");
                }
               
            }
        }
    }
}
