using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] commands = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = commands[0];
                string item = commands[1];
                switch (instruction)
                {
                    case "Collect":
                        Collect(journal, item);
                        break;
                    case "Drop":
                        Drop(journal, item);
                        break;
                    case "Combine Items":
                        string[] str = item.Split(":").ToArray();
                        string oldItem = str[0];
                        string newItem = str[1];
                        CombineItems(journal, oldItem, newItem);
                        break;
                    case "Renew":
                        Renew(journal, item);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", journal));
        }

        public static void Collect(List<string> list, string element)
        {
            if (!list.Contains(element))
            {
                list.Add(element);
            }
        }
        public static void Drop(List<string> list, string element)
        {
            if (list.Contains(element))
            {
                list.Remove(element);
            }
        }
        public static void CombineItems(List<string> list, string oldElement, string newElement)
        {
            if (list.Contains(oldElement))
            {
                int index = list.IndexOf(oldElement);
                list.Insert(index + 1, newElement);
            }
        }

        public static void Renew(List<string> list, string element)
        {
            if (list.Contains(element))
            {
                list.Remove(element);
                list.Add(element);
            }
        }
    }
}
