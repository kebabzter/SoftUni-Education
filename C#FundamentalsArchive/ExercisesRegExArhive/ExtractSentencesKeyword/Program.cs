using System;
using System.Text.RegularExpressions;

namespace ExtractSentencesKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string[] sentence = Console.ReadLine().Split('!', '.', '?');
            string pattern = $@"\b([{word}]+)\b";
            Regex regex = new Regex(pattern);
            foreach (var item in sentence)
            {
                var matches = regex.Matches(item);
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        Console.WriteLine(item.TrimStart());
                    }
                }
            }
        }
    }
}
