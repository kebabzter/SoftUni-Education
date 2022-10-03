using System;
using System.Collections.Generic;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, string>> pieces = new SortedDictionary<string, SortedDictionary<string, string>>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split("|",StringSplitOptions.RemoveEmptyEntries);
                pieces.Add(info[0],new SortedDictionary<string, string>());
                pieces[info[0]].Add(info[1],info[2]);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Stop")
                {
                    break;
                }
                string[] commands = input.Split("|",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Add":
                        if (pieces.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"{commands[1]} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(commands[1], new SortedDictionary<string, string>());
                            pieces[commands[1]].Add(commands[2], commands[3]);
                            Console.WriteLine($"{commands[1]} by {commands[2]} in {commands[3]} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieces.ContainsKey(commands[1]))
                        {
                            pieces.Remove(commands[1]);
                            Console.WriteLine($"Successfully removed {commands[1]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        if (pieces.ContainsKey(commands[1]))
                        {
                            string composer = string.Empty;
                            foreach (var item in pieces[commands[1]])
                            {
                                composer = item.Key;
                            }
                            pieces[commands[1]][composer] = commands[2];
                            Console.WriteLine($"Changed the key of {commands[1]} to {commands[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                }
            }

            foreach (var piece in pieces)
            {
                Console.Write($"{piece.Key} ");
                foreach (var item in piece.Value)
                {
                    Console.WriteLine($"-> Composer: {item.Key}, Key: {item.Value}");
                }
            }
        }
    }
}
