using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(.*?|(?<=\s))(<a( )?href=)(.*?)(>)(.*?)(<\/a>)";
            Regex regex = new Regex(pattern);
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }
                if (regex.IsMatch(input))
                {
                    sb.Append(regex.Match(input).Groups[1].Value);
                    string replace = regex.Match(input).Groups[2].Value.Replace("<a","[URL");
                    sb.Append(replace);
                    sb.Append(regex.Match(input).Groups[4].Value);
                    sb.Append("]");
                    sb.Append(regex.Match(input).Groups[6].Value);
                    sb.Append("[/URL]");
                    Console.WriteLine(sb);
                }
                else
                { 
                Console.WriteLine(input);
                }
            }
        }
    }
}
