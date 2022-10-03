using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> health = new Dictionary<string, int>();
            Dictionary<string, int> energy = new Dictionary<string, int>();

            while (true)
            {
                string[] lines = Console.ReadLine().Split(':');
                string command = lines[0];

                if (command == "Results")
                {
                    break;
                }

                if (command == "Add")
                {
                    string name = lines[1];
                    int hp = int.Parse(lines[2]);
                    int energiq = int.Parse(lines[3]);

                    if (health.ContainsKey(name))
                    {
                        health[name] += hp;
                    }
                    else
                    {
                        health[name] = hp;
                        energy[name] = energiq;
                    }
                }
                else if (command == "Attack")
                {
                    string attacker = lines[1];
                    string defender = lines[2];
                    int dmg = int.Parse(lines[3]);

                    if (!(health.ContainsKey(attacker) && health.ContainsKey(defender)))
                    {
                        continue;
                    }

                    health[defender] -= dmg;
                    energy[attacker]--;

                    if (health[defender] <= 0)
                    {
                        Console.WriteLine($"{defender} was disqualified!");
                        health.Remove(defender);
                        energy.Remove(defender);
                    }

                    if (energy[attacker] == 0)
                    {
                        Console.WriteLine($"{attacker} was disqualified!");
                        health.Remove(attacker);
                        energy.Remove(attacker);
                    }
                }
                else if (command == "Delete")
                {
                    string name = lines[1];

                    if (name == "All")
                    {
                        health.Clear();
                        energy.Clear();
                        continue;
                    }

                    health.Remove(name);
                    energy.Remove(name);
                }
            }

            health = health
                .OrderByDescending(h => h.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"People count: {health.Count}");

            foreach (var kvp in health)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} - {energy[kvp.Key]}");
            }
        }
    }
}