using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateSequenceQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(num);
            for (int i = 1; i <= 50; i++)
            {
                queue.Enqueue(num + 1);
                queue.Enqueue(num * 2 + 1);
                queue.Enqueue(num + 2);
                num = queue.ElementAtOrDefault(i);
            }
            Console.WriteLine(string.Join(" ", queue.Take(50)));
        }
    }
}
