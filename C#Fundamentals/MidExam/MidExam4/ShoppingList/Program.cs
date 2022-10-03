using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listShop = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            while (command != "Go Shopping!")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string instruction = commands[0];
                string item = commands[1];
                switch (instruction)
                {
                    case "Urgent":
                        Urgent(listShop, item);
                        break;
                    case "Unnecessary":
                        Unnecessary(listShop, item);
                        break;
                    case "Correct":
                        string newItem = commands[2];
                        Correct(listShop, item, newItem);
                        break;
                    case "Rearrange":
                        Rearrange(listShop, item);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", listShop));
        }

        public static void Urgent(List<string> list, string element)
        {
            if (!list.Contains(element))
            {
                list.Add(element);
                for (int i = list.Count - 1; i > 0; i--)
                {
                    list[i] = list[i - 1];
                }
                list[0] = element;
            }
        }

        public static void Unnecessary(List<string> list, string element)
        {
            if (list.Contains(element))
            {
                list.Remove(element);
            }
        }

        public static void Correct(List<string> list, string oldElement, string newElement)
        {
            if (list.Contains(oldElement))
            {
                int index = list.IndexOf(oldElement);
                list.Insert(index, newElement);
                list.Remove(oldElement);
            }
        }

        public static void Rearrange(List<string> list, string element)
        {
            if (list.Contains(element))
            {
                list.Remove(element);
                list.Add(element);
            }
        }

    }
}
