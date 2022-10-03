using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> judgeSystem = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "no more time")
                {
                    break;
                }
                string[] arrInput = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string userName = arrInput[0];
                string contest = arrInput[1];
                int points = int.Parse(arrInput[2]);
                if (judgeSystem.ContainsKey(contest))
                {
                    if (judgeSystem[contest].ContainsKey(userName))
                    {
                        if (judgeSystem[contest][userName] < points)
                        {
                            judgeSystem[contest][userName] = points;
                        }
                    }
                    else
                    {
                        judgeSystem[contest].Add(userName, points);
                    }
                }
                else
                {
                    judgeSystem.Add(contest, new Dictionary<string, int>());
                    judgeSystem[contest].Add(userName, points);
                }
            }

            foreach (var item in judgeSystem)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                int i = 1;
                foreach (var students in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{i}. {students.Key} <::> {students.Value}");
                    i++;
                }
            }

            Console.WriteLine("Individual standings:");
            Dictionary<string, int> individual = new Dictionary<string, int>();
            foreach (var item in judgeSystem)
            {
                foreach (var student in item.Value)
                {
                    if (individual.ContainsKey(student.Key))
                    {
                        individual[student.Key] += student.Value;
                    }
                    else
                    {
                        individual.Add(student.Key, student.Value);
                    }
                }
            }
            int j = 1;
            foreach (var individualStat in individual.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{j}. {individualStat.Key} -> {individualStat.Value}");
                j++;
            }

        }
    }
}
