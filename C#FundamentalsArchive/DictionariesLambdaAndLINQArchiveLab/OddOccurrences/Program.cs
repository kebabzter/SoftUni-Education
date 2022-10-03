using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> countWords = new Dictionary<string, int>();
            List<string> result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!countWords.ContainsKey(words[i]))
                {
                    countWords.Add(words[i], 1);
                }
                else
                {
                    countWords[words[i]]++;
                }
            }
            foreach (var item in countWords)
            {
                if (item.Value%2!=0)
                {
                    result.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
