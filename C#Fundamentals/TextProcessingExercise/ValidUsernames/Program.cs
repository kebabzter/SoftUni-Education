using System;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in text)
            {
                if ((word.Length>=3 && word.Length<=16)&&(word.All(x=>char.IsLetterOrDigit(x))||word.Contains("-")||word.Contains("_")))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
