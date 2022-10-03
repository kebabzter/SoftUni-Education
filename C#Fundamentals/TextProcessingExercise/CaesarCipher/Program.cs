using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.Append((char)(item+3));
            }
            Console.WriteLine(sb);
        }
    }
}
