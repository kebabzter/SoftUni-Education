using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments",0},
                { "motes", 0},
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string winner = string.Empty;
            bool flag = false;
            while (true)
            {
                string[] input = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];
                    if (materials.ContainsKey(material))
                    {
                        materials[material] += quantity;
                        if (materials[material]>=250)
                        {
                            materials[material] -= 250;
                            winner = material;
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material,quantity);
                        }
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            switch (winner)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }
            foreach (var item in materials.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
