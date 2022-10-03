using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line=File.ReadAllLines("text.txt");
            for (int i = 0; i < line.Length; i++)
            {
                string currentLine = line[i];
                int letterCount = CountLetters(currentLine);
                int punctuationCount = PunctuationCount(currentLine);
                line[i] = $"Line {i + 1}: {line[i]} ({letterCount})({punctuationCount})";
            }
            File.WriteAllLines("output.txt",line);
        }

        private static int PunctuationCount(string currentLine)
        {
            int count = 0;
            for (int i = 0; i < currentLine.Length; i++)
            {
                if (char.IsPunctuation(currentLine[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private static int CountLetters(string currentLine)
        {
            int count = 0;
            for (int i = 0; i < currentLine.Length; i++)
            {
                if (char.IsLetter(currentLine[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
