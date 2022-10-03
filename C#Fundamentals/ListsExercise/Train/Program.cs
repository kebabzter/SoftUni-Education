using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int maxCapacity= int.Parse(Console.ReadLine());
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }

                string[] command = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="Add")
                {
                    int element = int.Parse(command[1]);
                    train.Add(element);
                }
                else
                {
                    int passengers= int.Parse(command[0]);
                    for (int i = 0; i < train.Count; i++)
                    {
                        if (passengers+train[i]<=maxCapacity)
                        {
                            train[i] += passengers;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",train));
        }
    }
}
