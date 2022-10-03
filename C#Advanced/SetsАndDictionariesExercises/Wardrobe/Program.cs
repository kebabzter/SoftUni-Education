using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",",StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color,new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item,0);
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] search = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var cloth in wardrobe)
            {
                Console.WriteLine($"{cloth.Key} clothes:");
                foreach (var item in cloth.Value)
                {
                    if (cloth.Key==search[0]&&item.Key==search[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
