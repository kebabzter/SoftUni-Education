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
            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader("words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }
                    var currentWords = word
                        .Split(new char[] { ' ', '.', ',', '?', '!', ':', ';', '-', '[', ']', '{', '}', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();
                    foreach (var cWord in currentWords)
                    {
                        if (!wordsCount.ContainsKey(cWord))
                        {
                            wordsCount.Add(cWord,0);
                        }
                    }
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var currentWords = line
                        .Split(new char[] {' ','.',',','?','!',':',';','-','[',']','{','}','(',')' }, StringSplitOptions.RemoveEmptyEntries)
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
            }

            using (var writer = new StreamWriter("output.txt"))
            {
                var result = wordsCount
                    .OrderByDescending(w => w.Value)
                    .Select(w => $"{w.Key} - {w.Value}");

                foreach (var res in result)
                {
                    writer.WriteLine(res);
                }
            }
        }
    }
}
