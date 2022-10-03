using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"(=|\/)([A-Z][A-Za-z]{2,})\1");
            var matches = regex.Matches(text);
            List<string> list = new List<string>();
            int points = 0;
            foreach (Match match in matches)
            {
                list.Add(match.Groups[2].Value);
                points += match.Groups[2].Value.Length;
            }
            Console.Write($"Destinations: ");
            Console.WriteLine(string.Join(", ",list));
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
