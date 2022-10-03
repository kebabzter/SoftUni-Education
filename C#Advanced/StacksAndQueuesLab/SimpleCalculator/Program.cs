using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            Stack<string> numbers = new Stack<string>(input);

            while (numbers.Count>1)
            {
                int firstNum = int.Parse(numbers.Pop());
                string op = numbers.Pop();
                int secondNum = int.Parse(numbers.Pop());
                if (op=="+")
                {
                    numbers.Push((firstNum+secondNum).ToString());
                }
                else
                {
                    numbers.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(numbers.Pop());
        }
    }
}
