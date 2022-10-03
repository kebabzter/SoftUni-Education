using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> desk = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Ready")
                {
                    break;
                }
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Add":
                        string cardAdd = commands[1];
                        if (cards.Contains(cardAdd))
                        {
                            desk.Add(cardAdd);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Insert":
                        string cardInsert = commands[1];
                        int index = int.Parse(commands[2]);
                        if (!cards.Contains(cardInsert) || index<0 || index>=desk.Count)
                        {
                            Console.WriteLine("Error!");
                        }
                        else
                        {
                            desk.Insert(index, cardInsert);
                        }
                        break;
                    case "Remove":
                        string cardRemove = commands[1];
                        if (desk.Contains(cardRemove))
                        {
                            desk.Remove(cardRemove);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Swap":
                        string nameSwap1 = commands[1];
                        string nameSwap2 = commands[2];
                        int index1 = desk.IndexOf(nameSwap1);
                        int index2 = desk.IndexOf(nameSwap2);
                        desk[index1] = nameSwap2;
                        desk[index2] = nameSwap1;
                        break;
                    case "Shuffle":
                        desk.Reverse();
                        break;
                }

            }
            Console.WriteLine(string.Join(" ",desk));
        }
    }
}
