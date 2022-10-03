using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(str);
            int hot = int.Parse(Console.ReadLine());
            while (queue.Count>1)
            {
                for (int i = 1; i < hot; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
