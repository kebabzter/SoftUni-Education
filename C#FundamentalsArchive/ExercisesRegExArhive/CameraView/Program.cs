using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int skip = num[0];
            int take = num[1];
            string input = Console.ReadLine();
            string pattern = $@"(?<=\|<.{{{skip}}})([^|]{{0,{take}}})";
            Regex regex= new Regex(pattern);
            List<string> result = new List<string>();
            foreach (Match match in regex.Matches(input))
            {
                result.Add(match.Value);
            }
            Console.WriteLine(string.Join(", ", result));

        }
    }
}
