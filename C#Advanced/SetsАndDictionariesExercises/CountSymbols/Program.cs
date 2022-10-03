using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> countSymbol = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (!countSymbol.ContainsKey(text[i]))
                {
                    countSymbol.Add(text[i], 0);
                }
                countSymbol[text[i]]++;
            }
            foreach (var symbol in countSymbol)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
