using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                else if (input=="Paid")
                {
                    while (names.Count>0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(input);
                }
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
