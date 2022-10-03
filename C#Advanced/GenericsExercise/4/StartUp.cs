using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);
            }
            Box<int> box = new Box<int>(list);
            int[] swapIndex = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            box.Swap(list, swapIndex[0], swapIndex[1]);
            Console.WriteLine(box);
        }
    }
}
