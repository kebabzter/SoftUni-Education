using System;

namespace MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char letterFirst = char.Parse(Console.ReadLine());
            char letterSecond = char.Parse(Console.ReadLine());
            char letterNotPrint = char.Parse(Console.ReadLine());
            for (int i = letterFirst; i <= letterSecond; i++)
            {
                if (i!=letterNotPrint)
                {
                    for (int j = letterFirst; j <= letterSecond; j++)
                    {
                        if (j!=letterNotPrint)
                        {
                            for (int k = letterFirst; k <= letterSecond; k++)
                            {
                                if (k != letterNotPrint)
                                {
                                    Console.Write($"{(char)i}{(char)j}{(char)k} ");
                                }
                            }
                        }   
                    }
                }
            }
        }
    }
}
