using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] field = new int[size];
            for (int i = 0; i < initialIndexes.Length; i++)
            {
                if (initialIndexes[i] < 0 || initialIndexes[i] >= field.Length)
                {
                    continue;
                }
                field[initialIndexes[i]] = 1;
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int indexFly = int.Parse(commands[0]);
                string command = commands[1];
                int flyLength = int.Parse(commands[2]);
                if (indexFly < 0 || indexFly >= field.Length || field[indexFly] == 0)
                {
                    continue;
                }
                field[indexFly] = 0;
                while (true)
                {
                    if (command == "right")
                    {
                        indexFly += flyLength;
                    }
                    else if (command == "left")
                    {
                        indexFly -= flyLength;
                    }
                    if (indexFly >= field.Length || indexFly < 0)
                    {
                        break;
                    }
                    if (field[indexFly] == 0)
                    {
                        field[indexFly] = 1;
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
