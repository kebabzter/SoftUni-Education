using System;
using System.Linq;

namespace MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();
            int firstIndex = 0;
            int lastIndex = 0;
            while (true)
            {
                firstIndex = input.IndexOf(pattern);
                lastIndex = input.LastIndexOf(pattern);
                if (firstIndex != -1 && lastIndex != -1 && pattern.Length > 0)
                {

                    input = input.Remove(lastIndex, pattern.Length);
                    input = input.Remove(firstIndex, pattern.Length);

                    Console.WriteLine("Shaked it.");

                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }
            }
        }
    }
}
