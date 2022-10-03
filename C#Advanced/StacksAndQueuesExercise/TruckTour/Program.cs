using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> truck = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                truck.Enqueue(Console.ReadLine());
            }

            int length = truck.Count;
            int index = -1;

            for (int i = 0; i < length; i++)
            {
                bool isCompleted = true;
                int capacity = 0;
                for (int j = 0; j < length; j++)
                {
                    string currentValue = truck.Dequeue();
                    truck.Enqueue(currentValue);
                    if (isCompleted)
                    {
                        int[] arrCurrentValue = currentValue
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                        int amount = arrCurrentValue[0];
                        int distance = arrCurrentValue[1];
                        capacity += amount - distance;
                        if (capacity < 0)
                        {
                            isCompleted = false;
                        }
                    }
                }
                if (isCompleted)
                {
                    index = i;
                    break;
                }
                truck.Enqueue(truck.Dequeue());
            }
            Console.WriteLine(index);
        }
    }
}
