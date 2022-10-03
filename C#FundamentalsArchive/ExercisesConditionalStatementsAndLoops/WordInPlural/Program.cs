using System;

namespace WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();
            if (noun.EndsWith('y'))
            {
                Console.WriteLine(noun.Substring(0,noun.Length-1)+"ies");
            }
            else if (noun.EndsWith('o') || noun.EndsWith("ch") || noun.EndsWith('s') || noun.EndsWith("sh") || noun.EndsWith('x') || noun.EndsWith('z'))
            {
                Console.WriteLine(noun+"es");
            }
            else
            {
                Console.WriteLine(noun + "s");
            }
        }
    }
}
