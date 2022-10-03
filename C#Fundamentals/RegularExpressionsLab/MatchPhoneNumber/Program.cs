using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(\+359)( |-)2\2(\d{3})\2(\d{4})\b";
            string text = Console.ReadLine();
            MatchCollection matchcolect = Regex.Matches(text, patern);
            Console.WriteLine(string.Join(", ", matchcolect));
        }
    }
}
