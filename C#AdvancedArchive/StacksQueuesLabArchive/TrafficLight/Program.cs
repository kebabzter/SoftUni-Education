using System;
using System.Collections.Generic;

namespace TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int totalPass = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }
                else if (input=="green")
                {
                    for (int i = 0; i < countPass; i++)
                    {
                        if (queue.Count>0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            totalPass++;
                        }
                        else
                        {
                            break;
                        }
                       
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{totalPass} cars passed the crossroads.");
        }
    }
}
