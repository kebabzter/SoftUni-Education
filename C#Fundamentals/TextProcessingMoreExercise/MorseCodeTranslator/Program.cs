using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> morseToChar = new Dictionary<char, string>()
            {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {' ', "/"},
            {'.', ".-.-.-"},
            {',', "--..--"},
            {':', "---..."},
            {'?', "..--.."},
            {'!', "..--."},
            {'\'', ".----."},
            {'-', "-....-"},
            {'/', "-..-."},
            {'"', ".-..-."},
            {'@', ".--.-."},
            {'=', "-...-"}
            };
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder output = new StringBuilder();
            foreach (string s in input)
            {
                string[] current = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in current)
                {
                    if (morseToChar.ContainsValue(item))
                        output.Append(morseToChar.First(x => x.Value == item).Key);
                }
                output.Append(" ");
            }
            Console.WriteLine(output.ToString().ToUpper().TrimEnd());
        }
    }
}
