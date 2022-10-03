using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(str.Reverse());
            int result = 0;
            while (stack.Count>1)
            {
                int first = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int second = int.Parse(stack.Pop());
                if (sign=="+")
                {
                    result = first + second;
                    stack.Push(result.ToString());
                }
                else if (sign=="-")
                {
                    result = first - second;
                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
