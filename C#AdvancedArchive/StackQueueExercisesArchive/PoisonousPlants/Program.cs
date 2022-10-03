using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            Queue<int> indexRemove = new Queue<int>();
            int countDay = 0;
           
            while (true)
            {
                for (int i = 1; i < plants.Count; i++)
                {
                    if (plants[i - 1] < plants[i])
                    {
                        indexRemove.Enqueue(i);
                    }
                }
                if (indexRemove.Count==0)
                {
                    break;
                }
                int index = indexRemove.Dequeue();
                List<int> listPlants = new List<int>();
                for (int i = 0; i < plants.Count; i++)
                {
                    if (i == index)
                    {
                        if (indexRemove.Count == 0)
                        {
                            continue;
                        }
                        index = indexRemove.Dequeue();
                    }
                    else
                    {
                        listPlants.Add(plants[i]);
                    }
                }
                plants = new List<int> (listPlants);
                countDay++;
            }
            Console.WriteLine(countDay);
        }
    }
}
