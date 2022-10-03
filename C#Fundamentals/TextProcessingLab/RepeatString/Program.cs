using System;
using System.Text;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                int count = item.Length;
                for (int i = 0; i < count; i++)
                {
                    sb.Append(item);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
