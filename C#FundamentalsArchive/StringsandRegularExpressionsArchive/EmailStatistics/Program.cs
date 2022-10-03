using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmailStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^([A-Za-z]{5,})@(([a-z]{3,})(.com|.bg|.org))$";
            Regex regex = new Regex(pattern);
            Dictionary<string, List<string>> dictEmail = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string currentEmail = Console.ReadLine();
                if (regex.IsMatch(currentEmail))
                {
                    var match = regex.Match(currentEmail);
                    string user = match.Groups[1].Value;
                    string domain = match.Groups[2].Value;
                    if (dictEmail.ContainsKey(domain))
                    {
                        if (!dictEmail[domain].Contains(user))
                        {
                            dictEmail[domain].Add(user);
                        }
                    }
                    else
                    {
                        dictEmail[domain]= new List<string>();
                        dictEmail[domain].Add(user);
                    }
                }
            }
            var filter = dictEmail.OrderByDescending(x => x.Value.Count);
            foreach (var item in filter)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var email in item.Value)
                {
                    Console.WriteLine($"### {email}");
                }
            }
        }
    }
}
