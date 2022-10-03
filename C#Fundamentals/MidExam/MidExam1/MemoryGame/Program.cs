using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int moves = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                moves++;
                int[] indexes = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int firstIndex = indexes[0];
                int secondIndex = indexes[1];
                if (firstIndex == secondIndex || firstIndex < 0 || secondIndex < 0 || firstIndex > elements.Count - 1 || secondIndex > elements.Count - 1)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    int indexAdd = elements.Count / 2;
                    string addelement = "-" + moves + "a";
                    elements.Insert(indexAdd, addelement);
                    elements.Insert(indexAdd + 1, addelement);
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                    if (firstIndex > secondIndex)
                    {
                        elements.Remove(elements[secondIndex]);
                        elements.Remove(elements[firstIndex - 1]);
                    }
                    else
                    {
                        elements.Remove(elements[firstIndex]);
                        elements.Remove(elements[secondIndex - 1]);
                    }

                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }
            }
            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
