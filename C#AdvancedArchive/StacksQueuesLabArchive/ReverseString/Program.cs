using System;
using System.Collections.Generic;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            foreach (var item in str)
            {
                stack.Push(item.ToString());
            }
            Console.WriteLine(string.Join("",stack));
        }
    }
}
