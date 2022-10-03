using System;
using System.Text.RegularExpressions;

namespace MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b([0][x])?([A-F0-9]+)\b";
            Regex regex = new Regex(pattern);
            Console.WriteLine(string.Join(" ", regex.Matches(input)));
        }
    }
}
