using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> population = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input!= "report")
            {
                string[] inputArr = input.Split("|",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string city = inputArr[0];
                string country = inputArr[1];
                long countPeople = long.Parse(inputArr[2]);
                if (!population.ContainsKey(country))
                {
                    population.Add(country,new Dictionary<string, long>());
                }
                if (!population[country].ContainsKey(city))
                {
                    population[country].Add(city, 0);
                }
                population[country][city]=countPeople;
                input = Console.ReadLine();
            }
            foreach (var item in population.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value.Values.Sum()})");
                foreach (var cities in item.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{cities.Key}: {cities.Value}");
                }
            }

        }
    }
}
