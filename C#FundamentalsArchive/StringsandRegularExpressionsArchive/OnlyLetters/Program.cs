using System;
using System.Text.RegularExpressions;

namespace OnlyLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\d+";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(input))
            {
                int index = regex.Match(input).Index + regex.Match(input).Length;
                if (index>input.Length-1)
                {
                    break;
                }
                else
                {
                    input = input.Replace(regex.Match(input).ToString(), input[index].ToString());
                }
            }
            Console.WriteLine(input);
        }
    }
}
