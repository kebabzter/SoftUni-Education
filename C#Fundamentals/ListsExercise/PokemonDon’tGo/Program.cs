using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distance = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            while (true)
            {
                int index = int.Parse(Console.ReadLine());
                if (index<0)
                {
                    sum += distance[0];
                    int elem = distance[0];
                    distance.RemoveAt(0);
                    distance.Insert(0, distance[distance.Count - 1]);
                    ChangeElement(distance,elem);
                }
                else if (index>distance.Count-1)
                {
                    sum += distance[distance.Count - 1];
                    int removeElement = distance[distance.Count - 1];
                    distance.RemoveAt(distance.Count - 1);
                    distance.Add(distance[0]);
                    ChangeElement(distance, removeElement);
                }
                else
                {
                    int element = distance[index];
                    sum += distance[index];
                    distance.RemoveAt(index);
                    ChangeElement(distance, element);
                }
                if (distance.Count==0)
                {
                    break;
                }
               
            }
            Console.WriteLine(sum);
        }
        static void ChangeElement(List<int> list,int element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= element)
                {
                    list[i] += element;
                }
                else
                {
                    list[i] -= element;
                }
            }
        }
    }
}
