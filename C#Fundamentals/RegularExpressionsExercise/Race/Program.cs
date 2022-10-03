using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x)
                .ToDictionary(x=>x,x=>0);
            Regex regexLetter = new Regex(@"[A-Za-z]+");
            Regex regexDigit = new Regex(@"\d");
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "end of race")
                {
                    break;
                }

                var matchLetter = regexLetter.Matches(input);
                StringBuilder sb = new StringBuilder();
                foreach (Match letter in matchLetter)
                {
                    sb.Append(letter);
                }

                var matchDigit = regexDigit.Matches(input);
                int sum = 0;
                foreach (Match digit in matchDigit)
                {
                    sum += int.Parse(digit.ToString());
                }

                if (participants.ContainsKey(sb.ToString()))
                {
                    participants[sb.ToString()] += sum;
                }
            }

            string[] sorted = participants
                .OrderByDescending(x => x.Value)
                .Select(x=>x.Key)
                .Take(3)
                .ToArray();
            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
