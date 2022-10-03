using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);
            int count = 0;
            while (true)
            {
                bool flag = false;
                count++;
                string[] input = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i <= input.Length - 2; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];
                    if (material == "shards" || (material == "fragments") || material == "motes")
                    {
                        materials[material] += quantity;
                        if (materials[material] >= 250)
                        {
                            materials[material] -= 250;
                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, quantity);
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }
                }
                if (flag || count == 10)
                {
                    break;
                }
            }
            foreach (var item in materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
