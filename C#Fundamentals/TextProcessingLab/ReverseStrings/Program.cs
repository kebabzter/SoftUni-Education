using System;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }

                Console.WriteLine($"{input} = {string.Concat(input.ToCharArray().Reverse())}");
            }
        }
    }
}
