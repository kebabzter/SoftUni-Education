using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]=='(')
                {
                    stack.Push(i);
                }
                else if (str[i]==')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(str.Substring(startIndex,i-startIndex+1));
                }
            }  
        }
    }
}
