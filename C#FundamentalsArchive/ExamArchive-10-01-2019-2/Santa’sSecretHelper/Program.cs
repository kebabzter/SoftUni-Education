using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            List<string> children = new List<string>();
            string pattern = @"@([A-Za-z]+)[^@\-!:>]*!([G])!";
            Regex regex = new Regex(pattern);
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    sb.Append((char)(input[i]-key));
                }

                Match match = regex.Match(sb.ToString());

                if (match.Success)
                {
                    string child=match.Groups[1].Value;
                    children.Add(child);
                }
            }
            Console.WriteLine(string.Join("\n",children));
        }
    }
}
