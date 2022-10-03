using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charToReplace = { '-', ',', '.', '!', '?' };
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter wrt = new StreamWriter("output.txt"))
                {
                    int currentLine = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (currentLine % 2 == 0)
                        {
                            line = ReplaceAll(charToReplace, '@', line);
                            line = Reverse(line);
                            wrt.WriteLineAsync(line);
                        }
                        currentLine++;
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private static string Reverse(string line)
        {
            StringBuilder sb = new StringBuilder();
            string[] word = line.Split().ToArray();
            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(word[word.Length - i - 1]);
                sb.Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReplaceAll(char[] charToReplace, char v, string line)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if (charToReplace.Contains(currentSymbol))
                {
                    sb.Append(v);
                }
                else
                {
                    sb.Append(currentSymbol);
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
