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
                .Reverse()
                .ToArray();
            Stack<int> plates = new Stack<int>(platesArr);
            Stack<int> warriorOrcs = new Stack<int>();
            bool isOrcWin = false;
          
            for (int i = 1; i <= waves; i++)
            {
                int[] warrior = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                foreach (var num in warrior)
                {
                    warriorOrcs.Push(num);
                }

                if (i % 3 == 0)
                {
                    
                    int[] arr = plates.ToArray().Reverse().ToArray();
                    plates.Clear();
                    plates.Push(int.Parse(Console.ReadLine()));
                    foreach (var num in arr)
                    {
                        plates.Push(num);
                    }

                }
                for (int j = 0; j < warrior.Length; j++)
                {
                    int orcWarrior = warriorOrcs.Peek();
                    int plate = plates.Peek();

                    if (orcWarrior > plate)
                    {
                        while (orcWarrior > 0)
                        {
                            if (plates.Count == 0)
                            {
                                isOrcWin = true;
                                break;
                            }

                            plate = plates.Peek();

                            if (orcWarrior > plate)
                            {
                                plates.Pop();
                                warriorOrcs.Pop();
                                warriorOrcs.Push(orcWarrior -= plate);
                            }
                            else
                            {
                                plates.Pop();
                                plates.Push(plate -= orcWarrior);
                                warriorOrcs.Pop();
                                break;
                            }
                        }
                    }
                    else if (orcWarrior < plate)
                    {
                        warriorOrcs.Pop();
                        plates.Pop();
                        plates.Push(plate -= orcWarrior);
                    }
                    else
                    {
                        warriorOrcs.Pop();
                        plates.Pop();
                    }

                    if (plates.Count == 0)
                    {
                        isOrcWin = true;
                        break;
                    }
                }

                if (plates.Count == 0)
                {
                    isOrcWin = true;
                    break;
                }
            }

            if (isOrcWin)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

            if (warriorOrcs.Any())
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", warriorOrcs)}");
            }
        }
    }
}