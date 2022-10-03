using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    indexes.Push(i);
                }
                else if (input[i]==')')
                {
                    int startIndex = indexes.Pop();
                    Console.WriteLine(input.Substring(startIndex,i-startIndex+1));
                }
            }
        }
    }
}
