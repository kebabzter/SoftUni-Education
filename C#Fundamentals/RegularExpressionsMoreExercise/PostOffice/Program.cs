using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|",StringSplitOptions.RemoveEmptyEntries);
            Regex regexFirst = new Regex(@"([#$%*&])([A-Z]+)\1");
            Dictionary<char, int> letters = new Dictionary<char, int>();
            var firstGroup = regexFirst.Match(input[0]).Groups[2].Value;
            foreach (var item in firstGroup)
            {
                if (!letters.ContainsKey(item))
                {
                    letters.Add(item,0);
                }
            }

            Regex regexSecond = new Regex(@"(\d{2}):(\d{2})");
            var secondGroup = regexSecond.Matches(input[1]);
            foreach (Match item in secondGroup)
            {
                int code = int.Parse(item.Groups[1].Value);
                int count = int.Parse(item.Groups[2].Value)+1;
                if (letters.ContainsKey((char)code))
                {
                    letters[(char)code] = count;
                }
            }

            string[] third = input[2]
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var letter in letters)
            {
                foreach (var word in third)
                {
                    if (letter.Key==word[0]&&word.Length==letter.Value)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
