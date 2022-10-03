using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int task = int.Parse(Console.ReadLine());
            Stack<int> tasks = new Stack<int>(firstLine);
            Queue<int> thread = new Queue<int>(secondLine);

            while (true)
            {
                int tasksNum = tasks.Peek();
                int threadNum = thread.Peek();
                if (tasksNum==task)
                {
                    break;
                }
                if (threadNum >= tasksNum)
                {
                    tasks.Pop();
                    thread.Dequeue();
                }
                else
                {
                    thread.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {thread.Peek()} killed task {task}");
            Console.WriteLine(string.Join(" ",thread));
        }
    }
}
