using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> rank = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                string[] dataPass = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = dataPass[0];
                string password = dataPass[1];
                contestPass.Add(contest, password);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }
                string[] data = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string password = data[1];
                string user = data[2];
                int points = int.Parse(data[3]);
                if (contestPass.ContainsKey(contest) && contestPass[contest] == password)
                {
                    if (!rank.ContainsKey(user))
                    {
                        rank.Add(user, new Dictionary<string, int>());
                    }
                    if (!rank[user].ContainsKey(contest))
                    {
                        rank[user].Add(contest, points);
                    }
                    else
                    {
                        if (points > rank[user][contest])
                        {
                            rank[user][contest] = points;
                        }
                    }

                }
            }

            Dictionary<string, Dictionary<string, int>> bestUser = rank.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Best candidate is {bestUser.First().Key} with total {bestUser.First().Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var item in rank.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
