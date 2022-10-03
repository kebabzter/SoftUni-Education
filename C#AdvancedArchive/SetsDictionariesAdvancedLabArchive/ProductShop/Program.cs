using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                shops[shop].Add(product, price);
            }

            foreach (var item in shops)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
