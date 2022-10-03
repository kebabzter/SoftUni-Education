using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] bottles = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Queue<int> queueCups = new Queue<int>(cups);
            Stack<int> stackBottles = new Stack<int>(bottles);
            int water = 0;
            while (true)
            {
                if (queueCups.Peek() <= stackBottles.Peek())
                {
                    water += stackBottles.Peek() - queueCups.Peek();
                    queueCups.Dequeue();
                    stackBottles.Pop();

                }
                else
                {
                    int currBottle = stackBottles.Pop();
                    if (currBottle < queueCups.Peek())
                    {
                        int currCup = queueCups.Dequeue();
                        currCup -= currBottle;
                        while (true)
                        {
                            int nowBottle = stackBottles.Pop();
                            if (nowBottle < currCup)
                            {
                                currCup -= nowBottle;
                            }
                            else
                            {
                                water += nowBottle - currCup;
                                break;
                            }

                            if (stackBottles.Count == 0)
                            {
                                Console.WriteLine($"Cups: {currCup + " " + string.Join(" ", queueCups)}");
                                Console.WriteLine($"Wasted litters of water: {water}");
                                return;
                            }
                        }
                    }
                }
                if (queueCups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
                    Console.WriteLine($"Wasted litters of water: {water}");
                    break;
                }
                if (stackBottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
                    Console.WriteLine($"Wasted litters of water: {water}");
                    break;
                }
            }
        }
    }
}
