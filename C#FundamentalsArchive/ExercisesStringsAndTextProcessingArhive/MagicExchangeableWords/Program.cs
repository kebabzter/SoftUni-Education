using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string first = input[0].ToLower();
            string second = input[1].ToLower();
            if (CountSymbols(first) == CountSymbols(second))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
           
        }
        public static int CountSymbols(string str)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!list.Contains(str[i]))
                {
                    list.Add(str[i]);
                }
            }
            return list.Count();
        }
    }
}
