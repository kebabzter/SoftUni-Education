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
                string[] dataPass = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = dataPass[0];
                string pass = dataPass[1];
                if (!contestPass.ContainsKey(dataPass[0]))
                {
                    contestPass.Add(contest, pass);
                }
                else
                {
                    contestPass[contest] = pass;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }
                string[] data = input.Split("=>", StringSplitOptions.RemoveEmptyEntries); 
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
            int maxPoint = 0;
            string maxUser = string.Empty;
            foreach (var item in rank)
            {
                int currentPoint = 0;
                foreach (var contest in item.Value)
                {
                    currentPoint += contest.Value;
                }
                if (currentPoint > maxPoint)
                {
                    maxPoint = currentPoint;
                    maxUser = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {maxUser} with total {maxPoint} points.");
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
