using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(input);

            while (true)
            {
                string commands = Console.ReadLine().ToLower();
                if (commands=="end")
                {
                    break;
                }

                string[] command = commands
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0]=="remove")
                {
                    int countRemove = int.Parse(command[1]);
                    if (numbers.Count>=countRemove)
                    {
                        for (int i = 0; i < countRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
