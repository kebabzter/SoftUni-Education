using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarf = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Once upon a time")
                {
                    break;
                }
                string[] info = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentName = info[0];
                string currentColor = info[1];
                int currentPhysics = int.Parse(info[2]);


                string NameColor = currentName + ":" + currentColor;
                if (!dwarf.ContainsKey(NameColor))
                {
                    dwarf.Add(NameColor, currentPhysics);
                }
                else
                {
                    dwarf[NameColor] = Math.Max(dwarf[NameColor], currentPhysics);
                }
            }
            var sorted = dwarf
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarf.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count())
                .ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var item in sorted)
            {
                Console.WriteLine($"({item.Key.Split(':')[1]}) {item.Key.Split(':')[0]} <-> {item.Value}");
            }
        }
    }
}
