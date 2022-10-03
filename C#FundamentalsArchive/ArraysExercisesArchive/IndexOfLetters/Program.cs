using System;
using System.Linq;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            for (int i = 0; i <str.Length; i++)
            {
                Console.WriteLine($"{str[i]} -> {str[i]-97}");
            }
        }
    }
}
