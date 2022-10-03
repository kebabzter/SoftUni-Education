using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(new string[] { ",", ";", ":", ".", "!", "(", ")", "\"", "'", "\\", "/", "[", "]", " " }, StringSplitOptions.RemoveEmptyEntries);
            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
           
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].All(x => char.IsLower(x)))
                {
                    lowerCase.Add(text[i]);
                }
                else if (text[i].All(x => char.IsUpper(x)))
                {
                    upperCase.Add(text[i]);
                }
                else
                {
                    mixedCase.Add(text[i]);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }
    }
}
