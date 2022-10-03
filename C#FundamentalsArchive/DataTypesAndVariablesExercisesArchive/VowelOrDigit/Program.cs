using System;

namespace VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine().ToLower());
            if (char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
            }
            else if (symbol=='a'||symbol=='o'||symbol=='e'||symbol=='u'||symbol=='y'||symbol=='i')
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
