using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Stack<int> clothes = new Stack<int>(info);
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int countRack = 1;
            while (clothes.Count>0)
            {
                int cloth = clothes.Peek();
                sum += cloth;
                if (sum < capacity)
                {
                    clothes.Pop();
                    continue;
                }
                else if (sum == capacity)
                {
                    clothes.Pop();
                    if (clothes.Count > 0)
                    {
                        countRack++;
                    }
                    sum = 0;
                }
                else
                {
                    countRack++;
                    sum = 0;
                }
            }
            Console.WriteLine(countRack);
        }
    }
}
