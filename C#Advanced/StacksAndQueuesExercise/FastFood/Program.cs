using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] info = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Queue<int> queue = new Queue<int>(info);

            Console.WriteLine(queue.Max());
            bool flag = true;
            while (queue.Count > 0)
            {
                int current = queue.Peek();
                if (quantityFood >= current)
                {
                    quantityFood -= current;
                    queue.Dequeue();
                }
                else
                {
                    flag = false;
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
