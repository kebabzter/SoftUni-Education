using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patern = @"(^|(?<=\s))[A-Za-z\d]+([-_.][A-Za-z\d]+)*@[A-Za-z]+(\-[A-Za-z]+)*(\.[A-Za-z]+)+";
            Regex regex = new Regex(patern);
            var match = regex.Matches(text);
            foreach (Match item in match)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
