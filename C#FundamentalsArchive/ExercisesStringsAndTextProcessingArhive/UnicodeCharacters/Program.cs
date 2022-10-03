using System;
using System.Text;

namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)c));
            }
            Console.WriteLine(sb);
        }
    }
}
