using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < info.Length; j++)
                {
                    elements.Add(info[j]);
                }
            }
            Console.WriteLine(string.Join(" ", elements));

        }
    }
}
