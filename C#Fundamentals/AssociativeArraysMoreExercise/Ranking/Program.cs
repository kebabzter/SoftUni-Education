using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of contests")
                {
                    break;
                }
                string[] arrContest = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = arrContest[0];
                string password = arrContest[1];
                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword.Add(contest, password);
                }
            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of submissions")
                {
                    break;
                }
                string[] arrSubmissions = line
                   .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = arrSubmissions[0];
                string password = arrSubmissions[1];
                string userName = arrSubmissions[2];
                int points = int.Parse(arrSubmissions[3]);
                if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
                {
                    if (students.ContainsKey(userName))
                    {
                        if (students[userName].ContainsKey(contest))
                        {
                            if (students[userName][contest] < points)
                            {
                                students[userName][contest] = points;
                            }
                        }
                        else
                        {
                            students[userName].Add(contest, points);
                        }
                    }
                    else
                    {
                        students.Add(userName, new Dictionary<string, int>());
                        students[userName].Add(contest, points);
                    }
                }
            }

            string bestStudent = students.OrderBy(x => x.Value.Values.Sum()).Last().Key;
            int bestPoints = students.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var item in students.OrderBy(x => x.Key))
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
