using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"([^\d]+)([\d]+)");
            var matches = regex.Matches(input);
            StringBuilder sb = new StringBuilder();
            List<char> uniqueSymbol = new List<char>();
            foreach (Match match in matches)
            {
                string str = match.Groups[1].Value.ToUpper();
                int count = int.Parse(match.Groups[2].Value);
                for (int i = 0; i < count; i++)
                {
                    sb.Append(str);
                }
                if (count>0)
                {
                    foreach (var symbol in str)
                    {
                        if (!uniqueSymbol.Contains(symbol))
                        {
                            uniqueSymbol.Add(symbol);
                        }
                    }

                }
                
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbol.Count}");
            Console.WriteLine(sb);
        }
    }
}
