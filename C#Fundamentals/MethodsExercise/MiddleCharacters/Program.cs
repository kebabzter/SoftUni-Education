using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintMiddle(text);
        }

        static void PrintMiddle(string text)
        {
            int index = text.Length / 2;
            if (text.Length%2==0)
            {
                Console.WriteLine($"{text[index-1]}{text[index]}");
            }
            else
            {
                Console.WriteLine($"{text[index]}");
            }
        }
    }
}
