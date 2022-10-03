using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> openParentheses = new Stack<char>();
            string input = Console.ReadLine();
            bool isValid = true;
            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    openParentheses.Push(item);
                }
                else
                {
                    if (openParentheses.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    if (item == '}' && openParentheses.Peek() == '{'|| item == ']' && openParentheses.Peek() == '['|| item == ')' && openParentheses.Peek() == '(')
                    {
                        openParentheses.Pop();
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
