using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int bomb = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]=='>')
                {
                    bomb += text[i+1]-'0';
                    sb.Append(text[i]);
                }
                else if (bomb>0)
                {
                    bomb--;
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
