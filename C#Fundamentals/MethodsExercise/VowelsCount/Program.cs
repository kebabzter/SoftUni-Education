using System;
using System.Linq;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(CountVowels(text)); 
        }

        private static int CountVowels(string text)
        {
            int count = 0;
            text = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'o' || text[i] == 'u' || text[i] == 'e' || text[i] == 'i' || text[i] == 'y')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
