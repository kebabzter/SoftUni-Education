using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"@([A-Za-z]+)[^@\-!:>]*!([G])!");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                StringBuilder sb = new StringBuilder();
                foreach (var item in input)
                {
                    sb.Append((char)(item - key));
                }

                var match = regex.Match(sb.ToString());
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    Console.WriteLine(name);
                }
            }
        }
    }
}
