using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> rarity = new Dictionary<string, double>();
            Dictionary<string, List<double>> rating = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("<->",StringSplitOptions.RemoveEmptyEntries);
                if (!rarity.ContainsKey(input[0]))
                {
                    rarity.Add(input[0],0);
                    rating.Add(input[0],new List<double>());
                }
                rarity[input[0]] = double.Parse(input[1]);
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line== "Exhibition")
                {
                    break;
                }

                string[] commands = line.Split(": ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Rate":
                        string[] rate = commands[1].Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                        if (rate.Length!=2)
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        string plant = rate[0];
                        double currentRating = double.Parse(rate[1]);
                        if (rating.ContainsKey(plant))
                        {
                            rating[plant].Add(currentRating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        string[] rarities = commands[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        if (rarities.Length != 2)
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        string plantRarity = rarities[0];
                        double currentRarity = double.Parse(rarities[1]);
                        if (rarity.ContainsKey(plantRarity))
                        {
                            rarity[plantRarity]= currentRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        string restPlant = commands[1];
                        if (rating.ContainsKey(restPlant))
                        {
                            rating[restPlant].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            Dictionary<string,double> sorted = rarity.OrderByDescending(x => x.Value)
                .ThenByDescending(x =>
                {
                    List<double> list = rating[x.Key];
                    if (list.Count==0)
                    {
                        return 0;
                    }

                    return list.Average();
                   
                }).ToDictionary(x=>x.Key,x=>x.Value);

            Console.WriteLine("Plants for the exhibition: ");
            foreach (var item in sorted)
            {
                string name = item.Key;
                double rarit = item.Value;
                double raitings = 0;
                List<double> list = rating[item.Key];
                if (list.Count!=0)
                {
                    raitings=list.Average();
                }
                Console.WriteLine($"- {name}; Rarity: {rarit}; Rating: {raitings:f2}");
            }
        }
    }
}
