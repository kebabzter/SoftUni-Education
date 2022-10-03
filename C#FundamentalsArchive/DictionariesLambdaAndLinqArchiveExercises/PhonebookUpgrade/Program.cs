using System;
using System.Collections.Generic;

namespace PhonebookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input== "ListAll")
                {
                    foreach (var item in phonebook)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                    input = Console.ReadLine();
                    continue;
                }
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArr[0];
                string name = inputArr[1];
                if (command == "A")
                {
                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name, inputArr[2]);
                    }
                    else
                    {
                        phonebook[name] = inputArr[2];
                    }
                }
                else if (command == "S")
                {
                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
