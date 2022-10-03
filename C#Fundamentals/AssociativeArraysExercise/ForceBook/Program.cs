using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sideMembers = new Dictionary<string, List<string>>();
            Dictionary<string, string> userSide = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains(" | "))
                {
                    string[] info = input.Split(" | ",StringSplitOptions.RemoveEmptyEntries);
                    string side = info[0];
                    string user = info[1];
                    if (!userSide.ContainsKey(user))
                    {
                        userSide.Add(user,side);
                        if (!sideMembers.ContainsKey(side))
                        {
                            sideMembers.Add(side, new List<string>());
                        }
                        sideMembers[side].Add(user);
                    }
                }
                else
                {
                    string[] info = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = info[1];
                    string user = info[0];

                    if (!sideMembers.ContainsKey(side))
                    {
                        sideMembers.Add(side, new List<string>());
                    }

                    if (userSide.ContainsKey(user))
                    {
                        string oldSide = userSide[user];
                        sideMembers[oldSide].Remove(user);
                        sideMembers[side].Add(user);
                        userSide[user] = side;
                    }
                    else
                    {
                        userSide.Add(user, side);
                        sideMembers[side].Add(user);
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var result = sideMembers
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                item.Value.Sort();
                foreach (var user in item.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
