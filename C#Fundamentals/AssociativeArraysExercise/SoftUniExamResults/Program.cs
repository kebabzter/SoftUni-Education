using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> user = new Dictionary<string, int>();
            Dictionary<string, int> language = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }
                string[] info = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                if (info.Length>2)
                {
                    string currentLanguage = info[1];
                    int points = int.Parse(info[2]);
                    if (user.ContainsKey(name))
                    {
                        if (user[name] < points)
                        {
                            user[name] = points;
                        }
                    }
                    else
                    {
                        user.Add(name, points);
                    }
                    if (language.ContainsKey(currentLanguage))
                    {
                        language[currentLanguage]++;
                    }
                    else
                    {
                        language.Add(currentLanguage, 1);
                    }
                }
                else
                {
                    user.Remove(name);
                }
            }

            Console.WriteLine("Results:");
            var sortUser = user
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in sortUser)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");
            var sortLanguage = language
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in sortLanguage)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
