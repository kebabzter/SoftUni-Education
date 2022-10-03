using System;
using System.Collections.Generic;

namespace SalesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, decimal> salesByTown = new SortedDictionary<string, decimal>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentSale = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                decimal salesTown = decimal.Parse(currentSale[2]) * decimal.Parse(currentSale[3]);
                if (salesByTown.ContainsKey(currentSale[0]))
                {
                    salesByTown[currentSale[0]] += salesTown;
                }
                else
                {
                    salesByTown.Add(currentSale[0], salesTown);
                }
            }
            foreach (var item in salesByTown)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Sale(string town, string product, decimal price, decimal quantity)
        {
            Town = town;
            Product = product;
            Price = price;
            Quantity = quantity;
        }
    }
}
