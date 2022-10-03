using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                switch (command[0])
                {
                    case 1:
                        numbers.Push(command[1]);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                }
            }
        }
    }
}
