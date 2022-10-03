using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vlogger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                if (data.Length == 4)
                {
                    if (!vlogger.ContainsKey(name))
                    {
                        vlogger.Add(name, new Dictionary<string, HashSet<string>>());
                        vlogger[name].Add("followers", new HashSet<string>());
                        vlogger[name].Add("following", new HashSet<string>());
                    }
                }
                else if (data.Length == 3)
                {
                    string follow = data[2];
                    if (vlogger.ContainsKey(name) && vlogger.ContainsKey(follow) && name != follow)
                    {
                        vlogger[name]["following"].Add(follow);
                        vlogger[follow]["followers"].Add(name);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");
            int number = 1;
            foreach (var logger in vlogger.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {logger.Key} : {logger.Value["followers"].Count} followers, {logger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in logger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }
        }
    }
}
