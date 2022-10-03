using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int datura = 40;
            const int cherry = 60;
            const int smoke = 120;
            int sumDatura = 0;
            int sumCherry = 0;
            int sumSmoke = 0;
            int[] bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bombCasings = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            Queue<int> effects = new Queue<int>(bombEffects);
            Stack<int> casing = new Stack<int>(bombCasings);
            bool flag = true;
            bool threeOfEach = false;
            int sum = 0;
            while (effects.Count > 0 && casing.Count > 0)
            {
                if (flag)
                {
                    sum = effects.Peek() + casing.Peek();
                }
                else
                {
                    sum -= 5;
                }

                if (sum == datura)
                {
                    sumDatura++;
                    effects.Dequeue();
                    casing.Pop();
                    flag = true;
                }
                else if (sum == cherry)
                {
                    sumCherry++;
                    effects.Dequeue();
                    casing.Pop();
                    flag = true;
                }
                else if (sum == smoke)
                {
                    sumSmoke++;
                    effects.Dequeue();
                    casing.Pop();
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                if (sumDatura >= 3 && sumCherry >= 3 && sumSmoke >= 3)
                {
                    threeOfEach = true;
                    break;
                }
            }
            if (threeOfEach)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            if (casing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }
            Console.WriteLine($"Cherry Bombs: {sumCherry}");
            Console.WriteLine($"Datura Bombs: {sumDatura}");
            Console.WriteLine($"Smoke Decoy Bombs: {sumSmoke}");
        }
    }
}
