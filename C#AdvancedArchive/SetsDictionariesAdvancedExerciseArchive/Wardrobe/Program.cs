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
                                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] item = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < item.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(item[j]))
                    {
                        wardrobe[color].Add(item[j], 0);
                    }
                    wardrobe[color][item[j]]++;
                }
            }
            string[] lookFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string lookColor = lookFor[0];
            string lookClothing = lookFor[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var clothing in item.Value)
                {
                    if (item.Key == lookColor && clothing.Key == lookClothing)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }

                }
            }

        }
    }
}
