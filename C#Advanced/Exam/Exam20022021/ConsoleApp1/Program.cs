using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] platesArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(platesArr);
            Stack<int> warriorOrcs = new Stack<int>();
            for (int i = 1; i <= waves; i++)
            {
                int[] warrior = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                if (i % 3 == 0)
                {
                    int addPlates = int.Parse(Console.ReadLine());
                    plates.Enqueue(addPlates);
                }
                if (plates.Count == 0)
                {
                    break;
                }

                foreach (var item in warrior)
                {
                    warriorOrcs.Push(item);
                }

                while (plates.Count > 0 && warriorOrcs.Count > 0)
                {
                    int plate = plates.Peek();
                    int orc = warriorOrcs.Peek();
                    if (plate == orc)
                    {
                        plates.Dequeue();
                        warriorOrcs.Pop();
                    }
                    else if (orc > plate)
                    {
                        plates.Dequeue();
                        orc -= plate;
                        warriorOrcs.Pop();
                        warriorOrcs.Push(orc);
                    }
                    else
                    {
                        warriorOrcs.Pop();
                        plate -= orc;
                        plates.Dequeue();
                        plates.Enqueue(plate);
                    }
                }
            }
            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorOrcs)}");
                return;
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

        }
    }
}
