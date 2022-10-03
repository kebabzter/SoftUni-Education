using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex rgx = new Regex(@"\d");
            var matchesDigits = rgx.Matches(text);
            int threshold = 1;
            foreach (Match match in matchesDigits)
            {
                threshold *= int.Parse(match.ToString());
            }
            Console.WriteLine($"Cool threshold: {threshold}");

            Regex regex = new Regex(@"(::|\*\*)([A-Z][a-z]{2,})\1");
            var matches = regex.Matches(text);
            int countEmoji = matches.Count;
            Console.WriteLine($"{countEmoji} emojis found in the text. The cool ones are:");

            List<string> list = new List<string>();
            foreach (Match emoji in matches)
            {
                if (SumLetter(emoji.Groups[2].Value)>threshold)
                {
                    list.Add(emoji.ToString());
                }
            }
            if (list.Count>0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static int SumLetter(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sum += str[i];
            }
            return sum;
        }
    }
}
