using System;
using System.Collections.Generic;

namespace DecimalBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int number = int.Parse(Console.ReadLine());
            if (number==0)
            {
                Console.WriteLine("0");
            }
            while (number>0)
            {
                int rest = number % 2;
                stack.Push(rest);
                number /= 2;
            }
            Console.WriteLine(string.Join("", stack));
        }
    }
}
