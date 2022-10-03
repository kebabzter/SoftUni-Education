using System;
using System.Text;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char prevSymbol = '\0';
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (item!=prevSymbol)
                {
                    sb.Append(item);
                }
                prevSymbol = item;
            }
            Console.WriteLine(sb);
        }
    }
}
