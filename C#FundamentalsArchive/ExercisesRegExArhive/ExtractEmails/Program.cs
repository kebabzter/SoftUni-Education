using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<!\S)([a-z](?:_?[a-z0-9\-\.]+@[a-z\-]+\.[a-z]+([\.a-z]+)?))\b";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                foreach (Match item in regex.Matches(input))
                {
                    Console.WriteLine(item);
                }
               
            }
        }
    }
}
