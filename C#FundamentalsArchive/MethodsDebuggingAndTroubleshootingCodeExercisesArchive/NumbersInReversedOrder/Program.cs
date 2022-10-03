using System;
using System.Linq;

namespace NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ReverseNumber(input);
        }

        private static void ReverseNumber(string input)
        {
            Console.WriteLine(string.Concat(input.Reverse())); ;
        }
    }
}
