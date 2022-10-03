using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> fibonacci = new Stack<long>();
            int n = int.Parse(Console.ReadLine());
            fibonacci.Push(0);
            fibonacci.Push(1);
            for (int i = 0; i < n-1; i++)
            {
                long first = fibonacci.Pop();
                long second = fibonacci.Pop();
                fibonacci.Push(first);
                long num = first + second;
                fibonacci.Push(num);              
            }
            Console.WriteLine(fibonacci.Pop());
        }
    }
}
