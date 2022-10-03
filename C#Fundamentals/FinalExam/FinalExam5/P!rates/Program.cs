using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> populationCities = new Dictionary<string, long>();
            Dictionary<string, long> goldCities = new Dictionary<string, long>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Sail")
                {
                    break;
                }

                string[] targeted = input.Split("||",StringSplitOptions.RemoveEmptyEntries);
                if (!populationCities.ContainsKey(targeted[0]))
                {
                    populationCities.Add(targeted[0], 0);
                    goldCities.Add(targeted[0], 0);
                }
                populationCities[targeted[0]]+=long.Parse(targeted[1]);
                goldCities[targeted[0]]+= long.Parse(targeted[2]);
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] commands = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Plunder":
                        string town = commands[1];
                        long people = long.Parse(commands[2]);
                        long gold = long.Parse(commands[3]);
                        populationCities[town] -= people;
                        goldCities[town] -= gold;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        if (populationCities[town]<=0 || goldCities[town]<=0)
                        {
                            populationCities.Remove(town);
                            goldCities.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }

                        break;
                    case "Prosper":
                        string townPr = commands[1];
                        long goldPr = long.Parse(commands[2]);
                        if (goldPr<0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        goldCities[townPr] += goldPr;
                        Console.WriteLine($"{goldPr} gold added to the city treasury. {townPr} now has {goldCities[townPr]} gold.");
                        break;
                }
            }
            var sorted = goldCities
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            if (sorted.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key} -> Population: {populationCities[item.Key]} citizens, Gold: {item.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
