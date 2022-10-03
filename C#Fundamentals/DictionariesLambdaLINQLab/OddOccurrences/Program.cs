using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> countWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (countWords.ContainsKey(word))
                {
                    countWords[word]++;
                }
                else
                {
                    countWords.Add(word,1);
                }
            }

            foreach (var item in countWords.Where(x => x.Value % 2 != 0))
            {
                Console.Write($"{item.Key} ");
            }
        }
    }
}
