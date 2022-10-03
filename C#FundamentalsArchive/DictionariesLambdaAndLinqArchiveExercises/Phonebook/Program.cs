using System;
using System.Collections.Generic;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArr[0];
                string name = inputArr[1];
                if (command=="A")
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
                else if (command=="S")
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
