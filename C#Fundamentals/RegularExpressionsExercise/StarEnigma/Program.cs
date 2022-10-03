using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[starSTAR]");
            string patern = @"@([A-Za-z]+)[^@\-!:>]*?:(\d+)[^@\-!:>]*?!([AD])![^@\-!:>]*?->(\d+)";
            Regex regexDecrypt = new Regex(patern);
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var countMatch = regex.Matches(input);
                int count = countMatch.Count;
                StringBuilder sb = new StringBuilder();
                foreach (var item in input)
                {
                    sb.Append((char)(item-count));
                }

                var match = regexDecrypt.Match(sb.ToString());
                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups[1].Value;
                string type = match.Groups[3].Value;
                if (type=="A")
                {
                    attacked.Add(name);
                }
                else
                {
                    destroyed.Add(name);
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var item in attacked.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var item in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
