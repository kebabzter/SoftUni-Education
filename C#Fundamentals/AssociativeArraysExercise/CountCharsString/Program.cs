using System;
using System.Collections.Generic;

namespace CountCharsString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countChar = new Dictionary<char, int>();
            string input = Console.ReadLine();
            foreach (var symbol in input)
            {
                if (symbol == ' ')
                {
                    continue;
                }

                if (countChar.ContainsKey(symbol))
                {
                    countChar[symbol]++;
                }
                else
                {
                    countChar.Add(symbol, 1);
                }
            }

            foreach (var item in countChar)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}