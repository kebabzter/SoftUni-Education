using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            int position = 0;
            for (int i = 0; i < numberCommands; i++)
            {
                string[] commands = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
                switch (commands[0])
                {
                    case "Forward":
                        int forwardSteps = int.Parse(commands[1]);
                        if (position+forwardSteps<=numbers.Count-1)
                        {
                            position += forwardSteps;
                            numbers.RemoveAt(position);
                        }
                        break;
                    case "Back":
                        int backSteps = int.Parse(commands[1]);
                        if (position - backSteps >= 0)
                        {
                            position -= backSteps;
                            numbers.RemoveAt(position);
                        }
                        break;
                    case "Gift":
                        int index = int.Parse(commands[1]);
                        int number = int.Parse(commands[2]);
                        if (index>=0 && index<=numbers.Count-1)
                        {
                            numbers.Insert(index, number);
                            position = index;
                        }
                        break;
                    case "Swap":
                        int numberFirst = int.Parse(commands[1]);
                        int numberSecond = int.Parse(commands[2]);
                        if (numbers.Contains(numberFirst)&&numbers.Contains(numberSecond))
                        {
                            int firstIndex = numbers.IndexOf(numberFirst);
                            int secondIndex = numbers.IndexOf(numberSecond);
                            numbers[firstIndex] = numberSecond;
                            numbers[secondIndex] = numberFirst;
                        }
                        break;
                }
            }
            Console.WriteLine($"Position: {position}");
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
