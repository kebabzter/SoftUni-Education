using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<char> stringReverse = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                stringReverse.Push(str[i]);
            }

            while (stringReverse.Count>0)
            {
                Console.Write(stringReverse.Pop());
            }
        }
    }
}
