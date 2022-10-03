using System;
using System.Linq;

namespace InventoryMatcher
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
            string[] productPrice = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="done")
                {
                    break;
                }
                int index = Array.IndexOf(productName,input);
                Console.WriteLine($"{input} costs: {productPrice[index]}; Available quantity: {quantities[index]}");
            }
        }
    }
}
