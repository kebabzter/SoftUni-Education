using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLoootBox = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> secondLoootBox = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int sumClaimed = 0;
            while (true)
            {
                int first = firstLoootBox.Peek();
                int second = secondLoootBox.Peek();
                int sum = first + second;
                if (sum%2==0)
                {
                    sumClaimed += sum;
                    firstLoootBox.Dequeue();
                    secondLoootBox.Pop();
                }
                else
                {
                    firstLoootBox.Enqueue(second);
                    secondLoootBox.Pop();
                }
                if (firstLoootBox.Count==0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (secondLoootBox.Count==0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }
            if (sumClaimed>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumClaimed}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumClaimed}");
            }
        }
    }
}
