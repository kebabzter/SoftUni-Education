using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> children = new Queue<string>(input);

            int hotPotato = int.Parse(Console.ReadLine());
            while (children.Count > 1)
            {
                for (int i = 1; i < hotPotato; i++)
                {
                    children.Enqueue(children.Dequeue()); 
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
