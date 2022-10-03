using System;
using System.Text.RegularExpressions;

namespace Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            string map = Console.ReadLine();
            while (true)
            {
                string[] arr = Console.ReadLine().Split(' ');
                char symbol = char.Parse(arr[0]);
                int minCount = int.Parse(arr[1]);
                string pattern = $@"[{Regex.Escape(symbol.ToString())}]+";
                Regex regex = new Regex(pattern);
                foreach (Match item in regex.Matches(map))
                {
                    if (item.Length >= minCount)
                    {
                        Console.WriteLine($"Hideout found at index {item.Index} and it is with size {item.Length}!");
                        return;
                    }
                }
            }
        }
    }
}
