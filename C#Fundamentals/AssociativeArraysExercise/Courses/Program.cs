using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] info = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries);
                string cours = info[0];
                string student = info[1];
                if (!courses.ContainsKey(cours))
                {
                    courses.Add(cours, new List<string>());
                }
                courses[cours].Add(student);
            }
            var sorted = courses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x=>x.Key,x=>x.Value);
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.Sort();
                foreach (var name in item.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
