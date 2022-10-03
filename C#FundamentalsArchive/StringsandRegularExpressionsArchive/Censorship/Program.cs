using System;

namespace Censorship
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string sentence = Console.ReadLine();
            string replaceWord = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                replaceWord += "*";
            }
            while (sentence.Contains(word))
            {
                int index = sentence.IndexOf(word);
                sentence = sentence.Replace(word, replaceWord);
            }
            Console.WriteLine(sentence);
        }
    }
}
