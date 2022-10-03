using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(.*) @(.*) (\d+) (\d+)";
            Regex regex = new Regex(pattern);
            Dictionary<string, Dictionary<string, long>> music = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    string singer = match.Groups[1].Value;
                    string venue = match.Groups[2].Value;
                    int ticketsPrice = int.Parse(match.Groups[3].Value);
                    int ticketsCount = int.Parse(match.Groups[4].Value);
                    long money = ticketsCount * ticketsPrice;
                    if (!music.ContainsKey(venue))
                    {
                        music.Add(venue, new Dictionary<string, long>());
                    }
                    if (!music[venue].ContainsKey(singer))
                    {
                        music[venue].Add(singer, 0);
                    }
                    music[venue][singer] += money;
                }
                input = Console.ReadLine();
            }
            foreach (var item in music)
            {
                Console.WriteLine(item.Key);
                foreach (var singer in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
