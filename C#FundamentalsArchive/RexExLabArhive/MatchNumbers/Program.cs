using System;
using System.Text.RegularExpressions;

namespace MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            Regex regex = new Regex(pattern);
            Console.WriteLine(string.Join(" ", regex.Matches(input)));
        }
    }
}
