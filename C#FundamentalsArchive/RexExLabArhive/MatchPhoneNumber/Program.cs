using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([+][3][5][9])([- ]*)([2])\2([0-9]{3})\2([0-9]{4})\b";
            Regex regex = new Regex(pattern);
            Console.WriteLine(string.Join(", ", regex.Matches(input)));
        }
    }
}
