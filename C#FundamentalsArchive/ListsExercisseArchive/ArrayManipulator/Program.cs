using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "print")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                switch (command)
                {
                    case "add":
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);
                        numbers.Insert(index, element);
                        break;

                    case "addMany":
                        int indexMany = int.Parse(commands[1]);
                        int count = commands.Length - 2;
                        List<int> take = new List<int>(count);
                        for (int i = 2; i < commands.Length; i++)
                        {
                            take.Add(int.Parse(commands[i]));
                        }
                        numbers.InsertRange(indexMany, take);
                        break;

                    case "contains":
                        int containsElement = int.Parse(commands[1]);
                        if (numbers.Contains(containsElement))
                        {
                            Console.WriteLine(numbers.IndexOf(containsElement));
                        }
                        else
                        {
                            Console.WriteLine("-1");
                        }
                        break;

                    case "remove":
                        int removeIndex = int.Parse(commands[1]);
                        numbers.RemoveAt(removeIndex);
                        break;

                    case "shift":
                        int positions = int.Parse(commands[1]);
                        for (int i = 0; i < positions; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                        break;

                    case "sumPairs":
                        for (int i = 0; i < numbers.Count-1; i++)
                        {
                            numbers[i] += numbers[i + 1];
                            numbers.RemoveAt(i+1);
                        }
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
