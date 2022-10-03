using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] locks = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Stack<int> stackBullets = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);
            int valueIntelligence = int.Parse(Console.ReadLine());

            int countReloading = 0;
            int count = 0;
            while (true)
            {
                if (stackBullets.Pop() <= queueLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                countReloading++;
                count++;

                if (queueLocks.Count == 0 && stackBullets.Count == 0)
                {
                    int earned = valueIntelligence - count * priceBullet;
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${earned}");
                    break;
                }
                if (stackBullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
                    break;
                }
                if (countReloading == sizeBarrel)
                {
                    Console.WriteLine("Reloading!");
                    countReloading = 0;
                }
                if (queueLocks.Count == 0)
                {
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueIntelligence - count * priceBullet}");
                    break;
                }
            }
        }
    }
}
