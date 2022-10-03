using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @">>([A-Za-z]+)<<(\d+\.?\d+)!(\d+)";
            Regex regex = new Regex(patern);
            double sum = 0;
            List<string> furnitures = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Purchase")
                {
                    break;
                }

                var match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups[1].Value;
                double price = double.Parse(match.Groups[2].Value);
                double quantity= double.Parse(match.Groups[3].Value);
                furnitures.Add(name);
                sum += price * quantity;
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in furnitures)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
