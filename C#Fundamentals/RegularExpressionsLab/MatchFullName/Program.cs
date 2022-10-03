using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            string text = Console.ReadLine();
            MatchCollection matchcolect = Regex.Matches(text,patern);
            Console.WriteLine(string.Join(" ",matchcolect));
        }
    }
}
