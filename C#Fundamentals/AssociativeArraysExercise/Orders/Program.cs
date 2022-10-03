using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="buy")
                {
                    break;
                }
                string[] currentProduct = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string product = currentProduct[0];
                decimal price = decimal.Parse(currentProduct[1]);
                int quantity = int.Parse(currentProduct[2]);
                if (productPrice.ContainsKey(product))
                {
                    productPrice[product] = price;
                    productQuantity[product] += quantity;
                }
                else
                {
                    productPrice.Add(product,price);
                    productQuantity.Add(product,quantity);
                }
            }

            foreach (var item in productPrice)
            {
                Console.WriteLine($"{item.Key} -> {item.Value*productQuantity[item.Key]:f2}");
            }
        }
    }
}
