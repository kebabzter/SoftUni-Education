using System;
using System.Collections.Generic;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, string>> dragon = new Dictionary<string, SortedDictionary<string, string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = input[0];
                string name = input[1];
                int damage = 0;
                int health = 0;
                int armor = 0;
                if (input[2] == "null")
                {
                    damage = 45;
                }
                else
                {
                    damage = int.Parse(input[2]);
                }
                if (input[3] == "null")
                {
                    health = 250;
                }
                else
                {
                    health = int.Parse(input[3]);
                }
                if (input[4] == "null")
                {
                    armor = 10;
                }
                else
                {
                    armor = int.Parse(input[4]);
                }
                if (dragon.ContainsKey(type) && (dragon[type].ContainsKey(name)))
                {
                    dragon[type][name] = damage + " " + health + " " + armor;
                }
                if ((dragon.ContainsKey(type) && (!dragon[type].ContainsKey(name))))
                {
                    dragon[type].Add(name, damage + " " + health + " " + armor);
                }
                if (!dragon.ContainsKey(type))
                {
                    dragon.Add(type, new SortedDictionary<string, string>());
                    dragon[type].Add(name, damage + " " + health + " " + armor);
                }
            }
            foreach (var item in dragon)
            {
                int damagePoint = 0;
                int healthPoint = 0;
                int armorPoint = 0;
                int count = 0;
                foreach (var point in item.Value)
                {
                    count++;
                    damagePoint += int.Parse(point.Value.Split()[0]);
                    healthPoint += int.Parse(point.Value.Split()[1]);
                    armorPoint += int.Parse(point.Value.Split()[2]);
                }
                double averageDamage = 1.0 * damagePoint / count;
                double averageHealth = 1.0 * healthPoint / count;
                double averageArmor = 1.0 * armorPoint / count;
                Console.WriteLine($"{item.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var printName in item.Value)
                {
                    string damagePrint = printName.Value.Split()[0];
                    string healthPrint = printName.Value.Split()[1];
                    string armorPrint = printName.Value.Split()[2];
                    Console.WriteLine($"-{printName.Key} -> damage: {damagePrint}, health: {healthPrint}, armor: {armorPrint}");
                }

            }
        }
    }
}
