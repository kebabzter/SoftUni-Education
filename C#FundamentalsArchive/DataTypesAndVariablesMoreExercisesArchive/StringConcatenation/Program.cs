using System;
using System.Text;

namespace StringConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string take = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                string str = Console.ReadLine();
                if (take == "odd" && i % 2 != 0)
                {
                    sb.Append(str);
                    sb.Append(delimiter);
                }
                else if (take == "even" && i % 2 == 0)
                {
                    sb.Append(str);
                    sb.Append(delimiter);
                }
            }
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb);
        }
    }
}
