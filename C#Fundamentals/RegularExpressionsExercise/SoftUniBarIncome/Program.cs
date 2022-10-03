using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";
            Regex regex = new Regex(patern);
            double totalPrice = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }

                var match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups[1].Value;
                string product = match.Groups[2].Value;
                int count = int.Parse(match.Groups[3].Value);
                double price = double.Parse(match.Groups[4].Value);
                Console.WriteLine($"{name}: {product} - {count*price:f2}");
                totalPrice += count * price;
            }
            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
