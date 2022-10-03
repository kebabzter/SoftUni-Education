using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> logger = new Dictionary<string, Dictionary<string, HashSet<string>>>();

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
                    if (!logger.ContainsKey(name))
                    {
                        logger.Add(name, new Dictionary<string, HashSet<string>>());
                        logger[name].Add("followers", new HashSet<string>());
                        logger[name].Add("following", new HashSet<string>());
                    }
                }
                else if (data.Length == 3)
                {
                    string follow = data[2];
                    if (logger.ContainsKey(name) && logger.ContainsKey(follow) && name != follow)
                    {
                        logger[name]["following"].Add(follow);
                        logger[follow]["followers"].Add(name);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {logger.Count} vloggers in its logs.");
            int number = 1;
            foreach (var vlogger in logger.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }

        }
    }
}
