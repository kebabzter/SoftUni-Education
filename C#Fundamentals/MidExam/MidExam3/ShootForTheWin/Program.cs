using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                int indexTarget = int.Parse(input);

                if (indexTarget >= 0 && indexTarget < targets.Length)
                {
                    for (int i = 0; i < targets.Length; i++)
                    {
                        int temp = targets[indexTarget];

                        if (targets[i] != -1 && i != indexTarget)
                        {
                            if (targets[i] > temp)
                            {
                                targets[i] -= temp;
                            }
                            else if (targets[i] <= temp)
                            {
                                targets[i] += temp;

                            }
                        }
                    }
                    targets[indexTarget] = -1;
                    counter++;
                }
            }

            Console.Write($"Shot targets: {counter} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
