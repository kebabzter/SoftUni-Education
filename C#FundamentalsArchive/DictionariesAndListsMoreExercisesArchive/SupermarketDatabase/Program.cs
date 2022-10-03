using System;
using System.Collections.Generic;

namespace SupermarketDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> supermarket = new Dictionary<string, Product>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "stocked")
                {
                    break;
                }
                string[] product = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = product[0];
                double price = double.Parse(product[1]);
                int quantity = int.Parse(product[2]);
                Product currentProduct = new Product(name, price, quantity);
                if (!supermarket.ContainsKey(name))
                {
                    supermarket.Add(name,currentProduct);
                }
                else
                {
                    supermarket[name].Price = price;
                    supermarket[name].Quantity += quantity;
                }
            }
            double total = 0;
            foreach (var item in supermarket)
            {
                Console.WriteLine($"{item.Key}: ${item.Value.Price:F2} * {item.Value.Quantity} = ${item.Value.Price*item.Value.Quantity:F2}");
                total += item.Value.Price * item.Value.Quantity;
            }
            Console.WriteLine(new string('-',30));
            Console.WriteLine($"Grand Total: ${total:F2}");
        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
