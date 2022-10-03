using System;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(<p>(.*?)<\/p>)";
            Regex regex = new Regex(pattern);
            string patternSpaces = @"(\s\s+)";
            Regex regexSpace = new Regex(patternSpaces);
            StringBuilder sb = new StringBuilder();
            foreach (Match item in regex.Matches(input))
            {
                string text = item.Groups[2].Value.ToString();
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsLower(text[i])&&(!char.IsDigit(text[i])))
                    {
                        text = text.Replace(text[i], ' ');
                    }
                }
                text = regexSpace.Replace(text, " ");
                for (int j = 0; j < text.Length; j++)
                {
                    char symbol = text[j];
                    if (text[j]>=97 && text[j]<=109)
                    {
                        symbol = (char)(text[j] + 13);
                    }
                    else if(text[j]>=110&&text[j]<=122)
                    {
                       symbol = (char)(text[j] - 13);
                    }
                    sb.Append(symbol.ToString());
                }
            }
            Console.WriteLine(sb);
        }
    }
}
