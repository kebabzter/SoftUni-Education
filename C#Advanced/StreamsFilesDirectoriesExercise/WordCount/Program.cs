using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] line = File.ReadAllLines("words.txt");
            for (int i = 0; i < line.Length; i++)
            {
                var currentWords = line[i]
                   .Split(new char[] { ' ', '.', ',', '?', '!', ':', ';', '-', '[', ']', '{', '}', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => x.ToLower())
                   .ToArray();
                foreach (var cWord in currentWords)
                {
                    if (!wordsCount.ContainsKey(cWord))
                    {
                        wordsCount.Add(cWord, 0);
                    }
                }
            }

            string[] text = File.ReadAllLines("text.txt");
            for (int i = 0; i < text.Length; i++)
            {
                var currentWords = text[i]
                   .Split(new char[] { ' ', '.', ',', '?', '!', ':', ';', '-', '[', ']', '{', '}', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => x.ToLower())
                   .ToArray();
                foreach (var word in currentWords)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }

                }
            }

            var result = wordsCount.OrderByDescending(w => w.Value).Select(w => $"{w.Key} - {w.Value}");
            File.WriteAllLines("actualResults.txt", result);
        }
    }
}
