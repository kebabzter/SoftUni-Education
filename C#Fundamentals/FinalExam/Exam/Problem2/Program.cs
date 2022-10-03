using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(\W+|\w+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1";
            Regex regex = new Regex(patern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                var match = regex.Match(text);
                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(match.Groups[2].Value);
                    sb.Append(match.Groups[3].Value);
                    sb.Append(match.Groups[4].Value);
                    sb.Append(match.Groups[5].Value);
                    Console.WriteLine($"Password: {sb}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
