using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patern = @"(@|#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";
            Regex regex = new Regex(patern);
            var matches = regex.Matches(text);
            List<string> listStr = new List<string>();
            if (matches.Count==0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine($"{matches.Count} word pairs found!");
            foreach (Match match in matches)
            {
                string strFirst = match.Groups[2].Value;
                string strSecond = match.Groups[3].Value;
                strSecond = string.Concat(strSecond.ToCharArray().Reverse());
                if (strFirst==strSecond)
                {
                    listStr.Add(strFirst);
                }
            }
            if (listStr.Count==0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                for (int i = 0; i < listStr.Count; i++)
                {
                    Console.Write($"{listStr[i]} <=> {string.Concat(listStr[i].ToCharArray().Reverse())}");
                    if (i<listStr.Count-1)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}
