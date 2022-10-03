using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
           
            while (true)
            {
                string commands = Console.ReadLine();
                if (commands== "End")
                {
                    break;
                }
                string[] input = commands.Split().ToArray();
                string command = input[0];
                int index = int.Parse(input[1]);
                int manipulation = int.Parse(input[2]);

                switch (command)
                {
                    case "Shoot":
                        Shoot(targets, index, manipulation);
                        break;
                    case "Add":
                        Add(targets, index, manipulation);
                        break;
                    case "Strike":
                        Strike(targets, index, manipulation);
                        break;
                }
            }
            Console.WriteLine(string.Join("|", targets));

        }
        public static void Shoot(List<int> target, int i, int power)
        {
            if (i <= target.Count - 1 && i >= 0)
            {
                target[i] -= power;
                if (target[i] <= 0)
                {
                    target.Remove(target[i]);
                }
            }
        }

        public static void Add(List<int> target, int i, int value)
        {
            if (i <= target.Count - 1 && i >= 0)
            {
                target.Insert(i, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        public static void Strike(List<int> target, int i, int radius)
        {
            if (i - radius >= 0 && i + radius <= target.Count - 1)
            {
                int count = 2 * radius + 1;
                int index = i - radius;
                for (int j = 0; j < count; j++)
                {
                    target.RemoveAt(index);

                }
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}
