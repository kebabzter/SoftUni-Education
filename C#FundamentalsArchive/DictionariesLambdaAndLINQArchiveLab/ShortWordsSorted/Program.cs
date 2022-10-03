using System;
using System.Linq;

namespace ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separator = { ".", ",", ":", ";", "(", ")", "[", "]", "\"", "'", "\\", "/", "!", "?", " " };
            string[] words = Console.ReadLine().ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] result = words.Where(x => x.Length < 5).OrderBy(x => x).Distinct().ToArray();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
