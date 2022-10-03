using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int countPass = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                else if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            countPass++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{countPass} cars passed the crossroads.");
        }
    }
}
